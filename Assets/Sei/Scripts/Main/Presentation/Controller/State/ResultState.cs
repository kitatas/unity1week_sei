using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Common;
using Sei.Common.Presentation.Controller;
using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.View;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ResultState : BaseGameState
    {
        private readonly TimeUseCase _timeUseCase;
        private readonly SeController _seController;
        private readonly ResultView _resultView;

        public ResultState(TimeUseCase timeUseCase, SeController seController, ResultView resultView)
        {
            _timeUseCase = timeUseCase;
            _seController = seController;
            _resultView = resultView;
        }

        public override GameState state => GameState.Result;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _resultView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            _seController.Play(SeType.Result);

            await _resultView.DisplayAsync(token);

            RankingLoader.Instance.SendScoreAndShowRanking(_timeUseCase.GetTime());

            return GameState.None;
        }
    }
}