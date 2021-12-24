using Sei.Main.Presentation.View;
using UnityEngine;

namespace Sei.Main.Domain.Factory
{
    public sealed class EffectFactory
    {
        private readonly Transform _parent;

        public EffectFactory(Transform parent)
        {
            _parent = parent;
        }

        public void Generate(EffectView effectView, Vector3 position)
        {
            var effect = Object.Instantiate(effectView, _parent);
            effect.transform.position = position;
        }
    }
}