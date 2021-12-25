using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sei.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sei.Main.Presentation.View
{
    public sealed class ReadyView : MonoBehaviour
    {
        [SerializeField] private Image maskImage = default;
        [SerializeField] private TextMeshProUGUI readyText = default;

        private readonly float _animationTime = 0.3f;

        public void Init()
        {
            maskImage.rectTransform
                .DOSizeDelta(new Vector2(ViewConfig.WIDTH, 0.0f), 0.0f);

            readyText.rectTransform
                .DOAnchorPosX(ViewConfig.WIDTH, 0.0f);
        }

        public async UniTask DisplayAsync(CancellationToken token)
        {
            await maskImage.rectTransform
                .DOSizeDelta(new Vector2(ViewConfig.WIDTH, 115.0f), _animationTime)
                .WithCancellation(token);

            await readyText.rectTransform
                .DOAnchorPosX(0.0f, _animationTime)
                .WithCancellation(token);

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            await (
                maskImage.rectTransform
                    .DOSizeDelta(new Vector2(ViewConfig.WIDTH, 0.0f), _animationTime)
                    .WithCancellation(token),
                readyText.rectTransform
                    .DOAnchorPosX(ViewConfig.WIDTH * -1, _animationTime)
                    .WithCancellation(token)
            );
        }
    }
}