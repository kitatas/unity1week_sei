using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Main.Domain.UseCase;

namespace Sei.Main.Presentation.Controller
{
    public sealed class MainState : BaseGameState
    {
        private readonly HpUseCase _hpUseCase;

        public MainState(HpUseCase hpUseCase)
        {
            _hpUseCase = hpUseCase;
        }

        public override GameState state => GameState.Main;

        public override async UniTask InitAsync(CancellationToken token)
        {
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.WaitWhile(() =>
            {
                return _hpUseCase.IsAlive();
            }, cancellationToken: token);

            return GameState.Result;
        }
    }
}