using UnityEngine;

namespace Sei.Main.Presentation.View
{
    public sealed class EffectView : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2.0f);
        }
    }
}