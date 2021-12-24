using UnityEngine;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ItemController : MonoBehaviour
    {
        [SerializeField] private ItemTyp itemTyp = default;

        public ItemTyp type => itemTyp;

        public void Repopulate()
        {
            transform.position = GetRepopulatePosition();
        }

        private static Vector3 GetRepopulatePosition()
        {
            var radius = Random.Range(0.0f, 6.0f);
            var random = Random.Range(0f, 360f);
            var theta = random * Mathf.PI / 180f;
            var x = Mathf.Cos(theta) * radius;
            var y = Mathf.Sin(theta) * radius;
            return new Vector3(x, y, 0.0f);
        }
    }
}