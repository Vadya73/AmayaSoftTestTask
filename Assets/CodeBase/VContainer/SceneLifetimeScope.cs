using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.VContainer
{
    public class SceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<AnimatorController>(Lifetime.Singleton).AsSelf();
            builder.Register<GameController>(Lifetime.Singleton).AsSelf();
            builder.Register<FadeInOutComponent>(Lifetime.Singleton).AsSelf();
        }
    }
}
