using EFUK;
using Sei.Main.Domain.UseCase;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

namespace Sei.Main.Presentation.Controller
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerController : MonoBehaviour
    {
        private AccelUseCase _accelUseCase;
        private EffectUseCase _effectUseCase;
        private InputUseCase _inputUseCase;
        private PlayerMoveUseCase _playerMoveUseCase;

        [Inject]
        private void Construct(AccelUseCase accelUseCase, EffectUseCase effectUseCase, InputUseCase inputUseCase,
            PlayerMoveUseCase playerMoveUseCase)
        {
            _accelUseCase = accelUseCase;
            _effectUseCase = effectUseCase;
            _inputUseCase = inputUseCase;
            _playerMoveUseCase = playerMoveUseCase;
        }

        public void Init(HpUseCase hpUseCase)
        {
            this.OnTriggerExit2DAsObservable()
                .Subscribe(other =>
                {
                    if (other.TryGetComponent<FieldController>(out var field))
                    {
                        hpUseCase.SetZero();
                        _effectUseCase.Generate(EffectType.Explode, transform.position);
                    }
                })
                .AddTo(this);

            this.OnTriggerEnter2DAsObservable()
                .Where(_ => hpUseCase.IsAlive())
                .Subscribe(other =>
                {
                    if (other.TryGetComponent<ItemController>(out var item))
                    {
                        hpUseCase.Update(item.type);
                        _effectUseCase.Generate(EffectType.Get, transform.position);

                        item.Repopulate();
                        _effectUseCase.Generate(item.type, item.transform.position);
                    }
                })
                .AddTo(this);
        }

        public void Tick(float deltaTime)
        {
            var inputValue = _inputUseCase.GetInputDirection().GetSqrLength(Vector2.zero);
            _accelUseCase.UpdateAccel(inputValue, deltaTime);
            _playerMoveUseCase.Move(_inputUseCase.GetInputDirection() * _accelUseCase.GetAccel());
        }
    }
}