using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ReadyState : BaseGameState
    {
        private readonly HpUseCase _hpUseCase;
        private readonly ReadyView _readyView;

        public ReadyState(HpUseCase hpUseCase, ReadyView readyView)
        {
            _hpUseCase = hpUseCase;
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

            UniTask.Void(async _ =>
            {
                while (_hpUseCase.IsMax() == false)
                {
                    _hpUseCase.Update(Time.deltaTime * GameConfig.MAX_HP * 2.0f);
                    await UniTask.Yield(token);
                }
            }, token);

            await _readyView.DisplayAsync(token);

            return GameState.Main;
        }
    }
}