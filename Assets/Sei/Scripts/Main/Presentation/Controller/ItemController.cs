using DG.Tweening;
using UnityEngine;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ItemController : MonoBehaviour
    {
        [SerializeField] private ItemTyp itemTyp = default;

        public ItemTyp type => itemTyp;

        public void Init()
        {
            PlayScaleAnimation();
        }

        public void Repopulate()
        {
            transform.position = GetRepopulatePosition();
            PlayScaleAnimation();
        }

        private void PlayScaleAnimation()
        {
            DOTween.Sequence()
                .Append(transform
                    .DOScale(Vector3.zero, 0.0f)
                    .SetEase(Ease.Linear))
                .Append(transform
                    .DOScale(Vector3.one, 0.5f)
                    .SetEase(Ease.OutBack));
        }

        private static Vector3 GetRepopulatePosition()
        {
            var radius = Random.Range(0.0f, 10.0f);
            var random = Random.Range(0.0f, 360.0f);
            var theta = random * Mathf.PI / 180.0f;
            var x = Mathf.Cos(theta) * radius;
            var y = Mathf.Sin(theta) * radius;
            return new Vector3(x, y, 0.0f);
        }
    }
}