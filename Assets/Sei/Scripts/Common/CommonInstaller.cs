using System.Collections.Generic;
using Sei.Common.Data.DataStore;
using Sei.Common.Domain.Repository;
using Sei.Common.Domain.UseCase;
using Sei.Common.Presentation.Controller;
using Sei.Common.Presentation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sei.Common
{
    public sealed class CommonInstaller : LifetimeScope
    {
        [SerializeField] private BgmTable bgmTable = default;
        [SerializeField] private SeTable seTable = default;

        protected override void Configure(IContainerBuilder builder)
        {
            // DataStore
            builder.RegisterInstance<BgmTable>(bgmTable);
            builder.RegisterInstance<SeTable>(seTable);

            // Repository
            builder.Register<SoundRepository>(Lifetime.Scoped);

            // UseCase
            builder.Register<SoundUseCase>(Lifetime.Scoped).AsImplementedInterfaces();

            // Controller
            builder.Register<SceneLoader>(Lifetime.Singleton);

            // MonoBehaviour
            FindObjectOfType<DontDestroyController>().Init();
            builder.RegisterInstance<BgmController>(DontDestroyController.Instance.bgmController);
            builder.RegisterInstance<SeController>(DontDestroyController.Instance.seController);
            builder.RegisterInstance<TransitionMaskView>(DontDestroyController.Instance.maskView);

            autoInjectGameObjects = new List<GameObject>
            {
                DontDestroyController.Instance.bgmController.gameObject,
                DontDestroyController.Instance.seController.gameObject,
            };
        }
    }
}