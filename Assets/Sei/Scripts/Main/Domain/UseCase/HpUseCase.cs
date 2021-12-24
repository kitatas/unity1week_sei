using System;
using Sei.Main.Data.Entity;
using UniRx;

namespace Sei.Main.Domain.UseCase
{
    public sealed class HpUseCase
    {
        private readonly HpEntity _hpEntity;
        private readonly ReactiveProperty<int> _hp;

        public HpUseCase(HpEntity hpEntity)
        {
            _hpEntity = hpEntity;
            _hp = new ReactiveProperty<int>(_hpEntity.Get());
        }

        public IReadOnlyReactiveProperty<int> hp => _hp;

        public void Update(ItemTyp itemType)
        {
            var value = itemType switch
            {
                ItemTyp.Increase => 1,
                ItemTyp.Decrease => -1,
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
            _hpEntity.Add(value);
            _hp.Value = _hpEntity.Get();
        }

        public void SetZero()
        {
            _hpEntity.Set(0);
            _hp.Value = _hpEntity.Get();
        }

        public bool IsAlive() => _hpEntity.Get() > 0;
    }
}