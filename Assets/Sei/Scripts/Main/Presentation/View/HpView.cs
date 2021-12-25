using UnityEngine;
using UnityEngine.UI;

namespace Sei.Main.Presentation.View
{
    public sealed class HpView : MonoBehaviour
    {
        [SerializeField] private Image hpImage = default;

        public void Show(float value)
        {
            hpImage.fillAmount = Mathf.Clamp01(value / GameConfig.MAX_HP);
        }
    }
}