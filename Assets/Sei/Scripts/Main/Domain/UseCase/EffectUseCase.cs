using System;
using Sei.Main.Domain.Factory;
using Sei.Main.Domain.Repository;
using UnityEngine;

namespace Sei.Main.Domain.UseCase
{
    public sealed class EffectUseCase
    {
        private readonly EffectFactory _effectFactory;
        private readonly EffectRepository _effectRepository;

        public EffectUseCase(EffectFactory effectFactory, EffectRepository effectRepository)
        {
            _effectFactory = effectFactory;
            _effectRepository = effectRepository;
        }

        public void Generate(EffectType effectType, Vector3 position)
        {
            var effect = _effectRepository.Find(effectType);
            if (effect == null)
            {
                throw new ArgumentOutOfRangeException(nameof(effectType), effectType, null);
            }

            _effectFactory.Generate(effect.view, position);
        }

        public void Generate(ItemTyp itemType, Vector3 position)
        {
            switch (itemType)
            {
                case ItemTyp.Increase:
                    Generate(EffectType.ItemPlus, position);
                    break;
                case ItemTyp.Decrease:
                    Generate(EffectType.ItemMinus, position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
            }
        }
    }
}