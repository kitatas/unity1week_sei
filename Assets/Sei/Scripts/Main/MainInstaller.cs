using Sei.Main.Data.Entity;
using Sei.Main.Domain.UseCase;
using Sei.Main.Presentation.Controller;
using Sei.Main.Presentation.Presenter;
using VContainer;
using VContainer.Unity;

namespace Sei.Main
{
    public sealed class MainInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<GameStateEntity>(Lifetime.Scoped);

            // UseCase
            builder.Register<GameStateUseCase>(Lifetime.Scoped);

            // Controller
            builder.Register<ReadyState>(Lifetime.Scoped);
            builder.Register<MainState>(Lifetime.Scoped);
            builder.Register<ResultState>(Lifetime.Scoped);
            builder.Register<GameStateController>(Lifetime.Scoped);

            // Presenter
            builder.RegisterEntryPoint<GameStatePresenter>(Lifetime.Scoped);
        }
    }
}