using Sei.Main.Data.Entity;
using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.Controller;
using Sei.Main.Presentation.Presenter;
using Sei.Main.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sei.Main
{
    public sealed class MainInstaller : LifetimeScope
    {
        [SerializeField] private HpView hpView = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<GameStateEntity>(Lifetime.Scoped);
            builder.Register<HpEntity>(Lifetime.Scoped);

            // UseCase
            builder.Register<GameStateUseCase>(Lifetime.Scoped);
            builder.Register<HpUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<ReadyState>(Lifetime.Scoped);
            builder.Register<MainState>(Lifetime.Scoped);
            builder.Register<ResultState>(Lifetime.Scoped);
            builder.Register<GameStateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<GameStatePresenter>(Lifetime.Scoped);
            builder.RegisterEntryPoint<HpPresenter>(Lifetime.Scoped);

            // View
            builder.RegisterInstance<HpView>(hpView);
        }
    }
}