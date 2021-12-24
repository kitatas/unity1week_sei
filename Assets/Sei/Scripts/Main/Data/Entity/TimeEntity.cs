using Sei.Common.Data.Entity;

namespace Sei.Main.Data.Entity
{
    public sealed class TimeEntity : BaseEntity<float>
    {
        public TimeEntity()
        {
            Init(0.0f);
        }

        public void Add(float value)
        {
            Set(Get() + value);
        }
    }
}