using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.View;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ResultState : BaseGameState
    {
        private readonly TimeUseCase _timeUseCase;
        private readonly ResultView _resultView;

        public ResultState(TimeUseCase timeUseCase, ResultView resultView)
        {
            _timeUseCase = timeUseCase;
            _resultView = resultView;
        }

        public override GameState state => GameState.Result;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _resultView.Init();
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            await _resultView.DisplayAsync(token);

            RankingLoader.Instance.SendScoreAndShowRanking(_timeUseCase.GetTime());

            return GameState.None;
        }
    }
}