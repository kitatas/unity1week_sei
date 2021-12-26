using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MPUIKIT;
using UnityEngine;

namespace Sei.Common.Presentation.View
{
    public sealed class TransitionMaskView : MonoBehaviour
    {
        [SerializeField] private MPImage mask = default;
        private static readonly int _radius = Shader.PropertyToID("_CircleRadius");
        private readonly float _hide = 380.0f;
        private readonly float _show = 100.0f;

        public void Init()
        {
            DOTween.To(
                () => mask.material.GetFloat(_radius),
                x => mask.material.SetFloat(_radius, x),
                _show,
                0.0f);
            mask.DOFade(0.0f, 0.0f);
            mask.raycastTarget = false;
        }

        public async UniTask FadeInAsync(CancellationToken token)
        {
            mask.raycastTarget = true;
            await (
                DOTween.To(
                        () => mask.material.GetFloat(_radius),
                        x => mask.material.SetFloat(_radius, x),
                        _hide,
                        CommonConfig.TRANSITION_TIME)
                    .SetLink(gameObject)
                    .WithCancellation(token),
                mask.DOFade(1.0f, CommonConfig.TRANSITION_TIME)
                    .SetLink(gameObject)
                    .WithCancellation(token)
            );
        }

        public async UniTask FadeOutAsync(CancellationToken token)
        {
            await (
                DOTween.To(
                        () => mask.material.GetFloat(_radius),
                        x => mask.material.SetFloat(_radius, x),
                        _show,
                        CommonConfig.TRANSITION_TIME)
                    .SetLink(gameObject)
                    .WithCancellation(token),
                mask.DOFade(0.0f, CommonConfig.TRANSITION_TIME)
                    .SetLink(gameObject)
                    .WithCancellation(token)
            );

            mask.raycastTarget = false;
        }
    }
}