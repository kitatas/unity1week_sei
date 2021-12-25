using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Sei.Main.Presentation.View
{
    public sealed class ResultView : MonoBehaviour
    {
        [SerializeField] private Image background = default;
        [SerializeField] private CanvasGroup canvasGroup = default;

        private readonly float _animationTime = 0.3f;

        public void Init()
        {
            background.rectTransform
                .DOScale(Vector3.one * 0.8f, 0.0f);

            canvasGroup
                .DOFade(0.0f, 0.0f);

            canvasGroup.blocksRaycasts = false;
        }

        public async UniTask DisplayAsync(CancellationToken token)
        {
            await (
                background.rectTransform
                    .DOScale(Vector3.one, _animationTime)
                    .SetEase(Ease.OutBack)
                    .WithCancellation(token),
                canvasGroup
                    .DOFade(1.0f, _animationTime)
                    .SetEase(Ease.Linear)
                    .WithCancellation(token)
            );

            canvasGroup.blocksRaycasts = true;
        }
    }
}