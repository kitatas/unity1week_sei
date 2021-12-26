using Sei.Common;
using Sei.Common.Presentation.Controller;
using Sei.Common.Presentation.View;
using Sei.Title.Presentation.View;
using UnityEngine;
using VContainer;

namespace Sei.Title.Presentation.Controller
{
    public sealed class TitleController : MonoBehaviour
    {
        [SerializeField] private VolumeView volumeView = default;

        [Inject]
        private void Construct(BgmController bgmController, SeController seController, SceneLoader sceneLoader)
        {
            bgmController.Play(BgmType.Title);

            volumeView.InitBgm(bgmController);
            volumeView.InitSe(seController, seController.Play);

            foreach (var speaker in FindObjectsOfType<ButtonSpeaker>())
            {
                speaker.OnPush(seController.Play);
            }

            foreach (var loader in FindObjectsOfType<ButtonLoader>())
            {
                loader.OnPush(sceneLoader.LoadScene);
            }

            foreach (var animator in FindObjectsOfType<ButtonAnimator>())
            {
                animator.OnPush();
            }
        }
    }
}