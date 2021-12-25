using System;
using EFUK;
using Sei.Main.Data.Entity;
using UniRx;

namespace Sei.Main.Domain.UseCase
{
    public sealed class HpUseCase
    {
        private readonly HpEntity _hpEntity;
        private readonly ReactiveProperty<float> _hp;

        public HpUseCase(HpEntity hpEntity)
        {
            _hpEntity = hpEntity;
            _hp = new ReactiveProperty<float>(_hpEntity.Get());
        }

        public IReadOnlyReactiveProperty<float> hp => _hp;

        public void Update(ItemTyp itemType)
        {
            var value = itemType switch
            {
                ItemTyp.Increase => 1.5f,
                ItemTyp.Decrease => -0.5f,
                _ => throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null)
            };
            Update(value);
        }

        public void Update(float value)
        {
            _hpEntity.Add(value);
            _hp.Value = _hpEntity.Get();
        }

        public void Decrease(float deltaTime)
        {
            Update(deltaTime * -1);
        }

        public void SetZero()
        {
            _hpEntity.Set(0);
            _hp.Value = _hpEntity.Get();
        }

        public bool IsAlive() => _hpEntity.Get() > 0;

        public bool IsMax() => _hpEntity.Get().Equal(GameConfig.MAX_HP);
    }
}