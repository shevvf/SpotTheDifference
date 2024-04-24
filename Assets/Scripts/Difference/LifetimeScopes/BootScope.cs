using Difference.Game.EntryPoint;
using VContainer;
using VContainer.Unity;

namespace Difference.LifetimeScopes
{
    public class BootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntryPoint>();
        }
    }
}