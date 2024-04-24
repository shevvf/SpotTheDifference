using Difference.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Difference.LifetimeScopes
{
    public class UIPanelsScope : LifetimeScope
    {
        [field: SerializeField] public UIPanelView View { get; private set; }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UIPanelPresenter>();

            builder.RegisterInstance(View);
            builder.RegisterComponent(View.DestroyablePanel);
        }
    }
}