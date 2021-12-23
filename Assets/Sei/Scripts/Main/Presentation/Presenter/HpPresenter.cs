using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.View;
using UniRx;
using VContainer.Unity;

namespace Sei.Main.Presentation.Presenter
{
    public sealed class HpPresenter : IPostInitializable
    {
        private readonly HpUseCase _hpUseCase;
        private readonly HpView _hpView;

        public HpPresenter(HpUseCase hpUseCase, HpView hpView)
        {
            _hpUseCase = hpUseCase;
            _hpView = hpView;
        }

        public void PostInitialize()
        {
            _hpUseCase.hp
                .Subscribe(_hpView.Show)
                .AddTo(_hpView);
        }
    }
}