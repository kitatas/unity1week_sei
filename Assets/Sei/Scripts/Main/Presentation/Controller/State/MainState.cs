using System.Threading;
using Cysharp.Threading.Tasks;

namespace Sei.Main.Presentation.Controller
{
    public sealed class MainState : BaseGameState
    {
        public override GameState state => GameState.Main;

        public override async UniTask InitAsync(CancellationToken token)
        {
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            return GameState.Result;
        }
    }
}