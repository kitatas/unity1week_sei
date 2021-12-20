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
            return _soundRepository.FindBgm(bgmType).audioClip;
        }

        public AudioClip GetSe(SeType seType)
        {
            return _soundRepository.FindSe(seType).audioClip;
        }
    }
}