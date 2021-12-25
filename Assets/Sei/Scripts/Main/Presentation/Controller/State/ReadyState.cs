using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Main.Presentation.View;
using Object = UnityEngine.Object;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ReadyState : BaseGameState
    {
        private readonly ReadyView _readyView;

        public ReadyState(ReadyView readyView)
        {
            _readyView = readyView;
        }

        public override GameState state => GameState.Ready;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _readyView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            foreach (var item in Object.FindObjectsOfType<ItemController>())
            {
                item.Init();
            }

            await _readyView.DisplayAsync(token);

            return GameState.Main;
        }
    }
}