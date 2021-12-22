using System.Threading;
using Cysharp.Threading.Tasks;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ResultState : BaseGameState
    {
        public override GameState state => GameState.Result;

        public override async UniTask InitAsync(CancellationToken token)
        {
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            return GameState.None;
        }
    }
}