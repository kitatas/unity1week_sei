using Sei.Common.Data.Entity;

namespace Sei.Main.Data.Entity
{
    public sealed class HpEntity : BaseEntity<int>
    {
        public HpEntity()
        {
            Init(5);
        }

        public void Add(int value)
        {
            Set(Get() + value);
        }
    }
}