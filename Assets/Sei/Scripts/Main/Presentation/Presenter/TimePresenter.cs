using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace Sei.Main.Presentation.Presenter
{
    public sealed class TimePresenter : IPostInitializable
    {
        private readonly TimeUseCase _timeUseCase;
        private readonly TimeView _timeView;

        public TimePresenter(TimeUseCase timeUseCase, TimeView timeView)
        {
            _timeUseCase = timeUseCase;
            _timeView = timeView;
        }

        public void PostInitialize()
        {
            _timeUseCase.time
                .Subscribe(_timeView.Show)
                .AddTo(_timeView);
        }
    }
}