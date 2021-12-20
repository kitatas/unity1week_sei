using Sei.Common.Data.DataStore;

namespace Sei.Common.Domain.Repository
{
    public sealed class SoundRepository
    {
        private readonly BgmTable _bgmTable;
        private readonly SeTable _seTable;

        public SoundRepository(BgmTable bgmTable, SeTable seTable)
        {
            _bgmTable = bgmTable;
            _seTable = seTable;
        }

        public BgmData FindBgm(BgmType bgmType)
        {
            return _bgmTable.dataList
                .Find(x => x.bgmType == bgmType);
        }

        public SeData FindSe(SeType seType)
        {
            return _seTable.dataList
                .Find(x => x.seType == seType);
        }
    }
}