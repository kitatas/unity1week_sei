using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Main.Domain.UseCase;

namespace Sei.Main.Presentation.Controller
{
    public sealed class MainState : BaseGameState
    {
        private readonly HpUseCase _hpUseCase;
        private readonly PlayerController _playerController;

        public MainState(HpUseCase hpUseCase, PlayerController playerController)
        {
            _hpUseCase = hpUseCase;
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
                _playerController.Tick();

                return _hpUseCase.IsAlive();
            }, cancellationToken: token);

            return GameState.Result;
        }
    }
}