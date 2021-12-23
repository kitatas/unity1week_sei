using UnityEngine;

namespace Sei.Main.Presentation.Controller
{
    public sealed class ItemController : MonoBehaviour
    {
        [SerializeField] private ItemTyp itemTyp = default;

        public ItemTyp type => itemTyp;
    }
}