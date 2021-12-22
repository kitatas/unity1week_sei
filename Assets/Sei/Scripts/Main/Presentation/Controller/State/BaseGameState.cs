using System.Threading;
using Cysharp.Threading.Tasks;

namespace Sei.Main.Presentation.Controller
{
    public abstract class BaseGameState
    {
        public abstract GameState state { get; }

        public virtual async UniTask InitAsync(CancellationToken token)
        {

        }

        public virtual async UniTask<GameState> TickAsync(CancellationToken token)
        {
            return GameState.None;
        }
    }
}