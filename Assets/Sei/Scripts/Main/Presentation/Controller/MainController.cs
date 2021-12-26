using Sei.Common.Presentation.Controller;
using Sei.Common.Presentation.View;
using UnityEngine;
using VContainer;

namespace Sei.Main.Presentation.Controller
{
    public sealed class MainController : MonoBehaviour
    {
        [Inject]
        private void Construct(SeController seController, SceneLoader sceneLoader)
        {
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