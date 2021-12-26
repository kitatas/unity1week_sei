using DG.Tweening;
using EFUK;
using Sei.Common;
using Sei.Common.Presentation.Controller;
using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

namespace Sei.Main.Presentation.Controller
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerView))]
    [RequireComponent(typeof(GetItemView))]
    public sealed class PlayerController : MonoBehaviour
    {
        private AccelUseCase _accelUseCase;
        private EffectUseCase _effectUseCase;
        private InputUseCase _inputUseCase;
        private PlayerMoveUseCase _playerMoveUseCase;
        private SeController _seController;
        private PlayerView _playerView;
        private GetItemView _getItemView;

        [Inject]
        private void Construct(AccelUseCase accelUseCase, EffectUseCase effectUseCase, InputUseCase inputUseCase,
            PlayerMoveUseCase playerMoveUseCase, SeController seController)
        {
            _accelUseCase = accelUseCase;
            _effectUseCase = effectUseCase;
            _inputUseCase = inputUseCase;
            _playerMoveUseCase = playerMoveUseCase;
            _seController = seController;
            _playerView = GetComponent<PlayerView>();
            _getItemView = GetComponent<GetItemView>();
            _getItemView.Init();
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
                        _seController.Play(SeType.Destroy);

                        FindObjectOfType<Camera>()
                            .DOShakePosition(0.25f)
                            .SetLink(gameObject);
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

                        item.Repopulate();
                        _effectUseCase.Generate(item.type, transform.position);
                        _seController.Play(SeType.Get);

                        _getItemView.Play(item.type);
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

        public void Stop()
        {
            _effectUseCase.Generate(EffectType.Destroy, transform.position);
            _seController.Play(SeType.Get);

            _playerMoveUseCase.Stop();
            _playerView.Show(false);
        }
    }
}