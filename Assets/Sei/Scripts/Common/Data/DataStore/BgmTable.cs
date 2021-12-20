using System.Collections.Generic;
using UnityEngine;

namespace Sei.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(BgmTable), menuName = "DataTable/" + nameof(BgmTable), order = 0)]
    public sealed class BgmTable : ScriptableObject
    {
        [SerializeField] private List<BgmData> list = default;

        public List<BgmData> dataList => list;
    }
}