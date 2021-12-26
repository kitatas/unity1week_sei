using System;
using Sei.Common.Domain.Repository;
using Sei.Common.Domain.UseCase.Interface;
using UnityEngine;

namespace Sei.Common.Domain.UseCase
{
    public sealed class SoundUseCase : IBgmUseCase, ISeUseCase
    {
        private readonly SoundRepository _soundRepository;

        public SoundUseCase(SoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
        }

        public AudioClip GetBgm(BgmType bgmType)
        {
            var data = _soundRepository.FindBgm(bgmType);
            if (data == null)
            {
                throw new ArgumentOutOfRangeException(nameof(bgmType), bgmType, null);
            }

            return data.audioClip;
        }

        public AudioClip GetSe(SeType seType)
        {
            var data = _soundRepository.FindSe(seType);
            if (data == null)
            {
                throw new ArgumentOutOfRangeException(nameof(seType), seType, null);
            }

            return data.audioClip;
        }
    }
}