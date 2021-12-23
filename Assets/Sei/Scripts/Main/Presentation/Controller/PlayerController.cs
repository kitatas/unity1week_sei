using System;
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
        private InputUseCase _inputUseCase;
        private PlayerMoveUseCase _playerMoveUseCase;

        [Inject]
        private void Construct(AccelUseCase accelUseCase, InputUseCase inputUseCase,
            PlayerMoveUseCase playerMoveUseCase)
        {
            _accelUseCase = accelUseCase;
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
                    }
                })
                .AddTo(this);

            this.OnTriggerEnter2DAsObservable()
                .Subscribe(other =>
                {
                    if (other.TryGetComponent<ItemController>(out var item))
                    {
                        var addValue = item.type switch
                        {
                            ItemTyp.Increase => 1,
                            ItemTyp.Decrease => -1,
                            _ => throw new ArgumentOutOfRangeException(nameof(item.type), item.type, null)
                        };
                        hpUseCase.IncreaseHp(addValue);
                    }
                })
                .AddTo(this);
        }

        public void Tick()
        {
            var inputValue = _inputUseCase.GetInputDirection().GetSqrLength(Vector2.zero);
            _accelUseCase.UpdateAccel(inputValue);
            _playerMoveUseCase.Move(_inputUseCase.GetInputDirection() * _accelUseCase.GetAccel());
        }
    }
}