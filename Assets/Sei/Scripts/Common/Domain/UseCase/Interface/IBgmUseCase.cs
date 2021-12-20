using UnityEngine;

namespace Sei.Common.Domain.UseCase.Interface
{
    public interface IBgmUseCase
    {
        AudioClip GetBgm(BgmType bgmType);
    }
}