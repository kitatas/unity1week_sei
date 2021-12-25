using TMPro;
using UnityEngine;

namespace Sei.Main.Presentation.View
{
    public sealed class HpView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpText = default;

        public void Show(float value)
        {
            hpText.text = $"{value: 0.00}";
        }
    }
}