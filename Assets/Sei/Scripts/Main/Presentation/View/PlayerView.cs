using UnityEngine;

namespace Sei.Main.Presentation.View
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer body = default;

        public void Show(bool value)
        {
            body.enabled = value;
        }
    }
}