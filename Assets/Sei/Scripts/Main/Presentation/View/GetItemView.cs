using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Sei.Main.Presentation.View
{
    public sealed class GetItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemText = default;
        private readonly float _height = 75.0f;
        private readonly float _animationTime = 0.25f;

        private Sequence _sequence;

        public void Init()
        {
            itemText
                .DOFade(0.0f, 0.0f);
            itemText.rectTransform
                .DOAnchorPosY(_height * -1, 0.0f);
        }

        public void Play(ItemTyp itemType)
        {
            _sequence?.Kill();

            SetText(itemType);

            _sequence = DOTween.Sequence()
                .Append(itemText
                    .DOFade(0.0f, 0.0f))
                .Join(itemText.rectTransform
                    .DOAnchorPosY(_height * -1, 0.0f))
                .Append(itemText
                    .DOFade(1.0f, _animationTime))
                .Join(itemText.rectTransform
                    .DOAnchorPosY(0.0f, _animationTime))
                .Append(itemText
                    .DOFade(0.0f, _animationTime))
                .Join(itemText.rectTransform
                    .DOAnchorPosY(_height, _animationTime));
        }

        private void SetText(ItemTyp itemType)
        {
            itemText.text = itemType switch
            {
                ItemTyp.Increase => "+",
                ItemTyp.Decrease => "-",
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
        }
    }
}