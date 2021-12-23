using EFUK;
using Sei.Main.Domain.UseCase;
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

        public void Tick()
        {
            var inputValue = _inputUseCase.GetInputDirection().GetSqrLength(Vector2.zero);
            _accelUseCase.UpdateAccel(inputValue);
            _playerMoveUseCase.Move(_inputUseCase.GetInputDirection() * _accelUseCase.GetAccel());
        }
    }
}