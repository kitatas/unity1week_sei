using Sei.Common.Data.Entity;

namespace Sei.Main.Data.Entity
{
    public sealed class AccelEntity : BaseEntity<float>
    {
        public AccelEntity()
        {
            Init(0.0f);
        }
    }
}