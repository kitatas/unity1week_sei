using VContainer;
using VContainer.Unity;

namespace Sei.Common.Presentation
{
    public sealed class DontDestroyInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
        }
    }
}