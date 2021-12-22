using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Sei.Main.Presentation.Controller
{
    public sealed class GameStateController
    {
        private readonly List<BaseGameState> _states;

        public GameStateController(ReadyState readyState, MainState mainState, ResultState resultState)
        {
            _states = new List<BaseGameState>
            {
                readyState,
                mainState,
                resultState,
            };
        }

        public async UniTaskVoid InitAsync(CancellationToken token)
        {
            foreach (var state in _states)
            {
                state.InitAsync(token).Forget();
            }
        }

        public async UniTask<GameState> TickAsync(GameState state, CancellationToken token)
        {
            var currentState = _states.Find(x => x.state == state);
            if (currentState == null)
            {
                return GameState.None;
            }

            return await currentState.TickAsync(token);
        }
    }
}