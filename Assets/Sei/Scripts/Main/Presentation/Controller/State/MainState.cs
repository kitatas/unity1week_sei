using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Main.Domain.UseCase;
using UnityEngine;

namespace Sei.Main.Presentation.Controller
{
    public sealed class MainState : BaseGameState
    {
        private readonly HpUseCase _hpUseCase;
        private readonly TimeUseCase _timeUseCase;
        private readonly PlayerController _playerController;

        public MainState(HpUseCase hpUseCase, TimeUseCase timeUseCase, PlayerController playerController)
        {
            _hpUseCase = hpUseCase;
            _timeUseCase = timeUseCase;
            _playerController = playerController;
        }

        public override GameState state => GameState.Main;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _playerController.Init(_hpUseCase);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.WaitWhile(() =>
            {
                var deltaTime = Time.deltaTime;
                _hpUseCase.Decrease(deltaTime);
                _timeUseCase.Update(deltaTime);
                _playerController.Tick(deltaTime);

                return _hpUseCase.IsAlive();
            }, cancellationToken: token);

            _playerController.Stop();

            return GameState.Result;
        }
    }
}