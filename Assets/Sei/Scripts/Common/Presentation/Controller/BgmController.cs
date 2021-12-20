using Sei.Common.Domain.UseCase.Interface;
using VContainer;

namespace Sei.Common.Presentation.Controller
{
    public sealed class BgmController : BaseSoundController
    {
        private IBgmUseCase _bgmUseCase;

        [Inject]
        private void Construct(IBgmUseCase bgmUseCase)
        {
            _bgmUseCase = bgmUseCase;
        }

        public void Play(BgmType bgmType)
        {
            var clip = _bgmUseCase.GetBgm(bgmType);
            if (clip == null || audioSource.clip == clip)
            {
                return;
            }

            audioSource.clip = clip;
            audioSource.Play();
        }

        public void Stop()
        {
            audioSource.Stop();
        }
    }
}