using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Sei.Common.Presentation.View
{
    public sealed class TransitionMaskView : MonoBehaviour
    {
        [SerializeField] private Image mask = default;

        public void Init()
        {
            mask.DOFade(0.0f, 0.0f);
        }

        public async UniTask FadeInAsync(CancellationToken token)
        {
            await mask
                .DOFade(1.0f, CommonConfig.TRANSITION_TIME)
                .WithCancellation(token);
        }

        public async UniTask FadeOutAsync(CancellationToken token)
        {
            await mask
                .DOFade(0.0f, CommonConfig.TRANSITION_TIME)
                .WithCancellation(token);
        }
    }
}