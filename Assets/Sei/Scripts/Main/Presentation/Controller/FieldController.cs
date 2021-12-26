using DG.Tweening;
using MPUIKIT;
using UnityEngine;

namespace Sei.Main.Presentation.Controller
{
    public sealed class FieldController : MonoBehaviour
    {
        [SerializeField] private MPImage field = default;
        private static readonly int _gradientRotation = Shader.PropertyToID("_GradientRotation");

        private void Start()
        {
            DOTween.Sequence()
                .Append(DOTween.To(
                    () => field.material.GetFloat(_gradientRotation),
                    value => field.material.SetFloat(_gradientRotation, value),
                    360.0f,
                    2.0f))
                .SetLoops(-1, LoopType.Restart)
                .SetLink(gameObject);
        }
    }
}