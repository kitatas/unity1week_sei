using DG.Tweening;
using UnityEngine;

namespace Sei.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class ButtonAnimator : MonoBehaviour
    {
        private Vector3 _currentScale;
        private readonly float _rate = 0.85f;
        private readonly float _animationTime = 0.1f;

        private ButtonActivator _buttonActivator;
        private ButtonActivator buttonActivator => _buttonActivator ??= GetComponent<ButtonActivator>();

        public void OnPush()
        {
            _currentScale = transform.localScale;

            buttonActivator.OnPush(() =>
            {
                DOTween.Sequence()
                    .Append(buttonActivator.button.image.rectTransform
                        .DOScale(_currentScale * _rate, _animationTime))
                    .Append(buttonActivator.button.image.rectTransform
                        .DOScale(_currentScale, _animationTime));
            });
        }
    }
}