using TMPro;
using UnityEngine;

namespace Sei.Main.Presentation.View
{
    public sealed class TimeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText = default;

        public void Show(float value)
        {
            timeText.text = $"{value: 0.00}";
        }
    }
}