using Sei.Main.Data.DataStore;

namespace Sei.Main.Domain.Repository
{
    public sealed class EffectRepository
    {
        private readonly EffectTable _effectTable;

        public EffectRepository(EffectTable effectTable)
        {
            _effectTable = effectTable;
        }

        public EffectData Find(EffectType effectType)
        {
            return _effectTable.list
                .Find(x => x.type == effectType);
        }
    }
}