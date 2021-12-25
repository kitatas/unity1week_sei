using Sei.Common.Data.Entity;
using UnityEngine;

namespace Sei.Main.Data.Entity
{
    public sealed class HpEntity : BaseEntity<float>
    {
        public HpEntity()
        {
            Init(0.0f);
        }

        public void Add(float value)
        {
            Set(Mathf.Clamp(Get() + value, 0.0f, GameConfig.MAX_HP));
        }
    }
}