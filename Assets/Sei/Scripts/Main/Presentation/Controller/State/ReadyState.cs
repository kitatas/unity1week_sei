using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ReadyState : BaseGameState
    {
        public override GameState state => GameState.Ready;

        public override async UniTask InitAsync(CancellationToken token)
        {
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            foreach (var item in Object.FindObjectsOfType<ItemController>())
            {
                item.Init();
            }

            return GameState.Main;
        }
    }
}