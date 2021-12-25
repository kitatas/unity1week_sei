using Sei.Common;
using Sei.Common.Presentation.Controller;
using Sei.Common.Presentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Sei.Result.Presentation.Controller
{
    public sealed class ResultController : MonoBehaviour
    {
        [SerializeField] private Button closeButton = default;

        [Inject]
        private void Construct(SeController seController, SceneLoader sceneLoader)
        {
            foreach (var speaker in FindObjectsOfType<ButtonSpeaker>())
            {
                speaker.OnPush(seController.Play);
            }

            foreach (var animator in FindObjectsOfType<ButtonAnimator>())
            {
                animator.OnPush();
            }

            closeButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    sceneLoader.UnloadSceneAsync(SceneType.Ranking);
                    sceneLoader.LoadScene(SceneType.Title);
                })
                .AddTo(this);
        }
    }
}