using System;
using Sei.Common.Domain.UseCase.Interface;
using VContainer;

namespace Sei.Common.Presentation.Controller
{
    public sealed class SeController : BaseSoundController
    {
        private ISeUseCase _seUseCase;

        [Inject]
        private void Construct(ISeUseCase seUseCase)
        {
            _seUseCase = seUseCase;
        }

        public void Play(SeType seType)
        {
            var clip = _seUseCase.GetSe(seType);
            if (clip == null)
            {
                return;
            }

            audioSource.PlayOneShot(clip);
        }

        public void Play(ButtonType buttonType)
        {
            var seType = buttonType switch
            {
                ButtonType.Decision => SeType.Decision,
                ButtonType.Cancel   => SeType.Cancel,
                _ => throw new ArgumentOutOfRangeException(nameof(buttonType), buttonType, null)
            };

            Play(seType);
        }
    }
}