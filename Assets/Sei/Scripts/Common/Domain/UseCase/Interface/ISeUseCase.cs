using UnityEngine;

namespace Sei.Common.Domain.UseCase.Interface
{
    public interface ISeUseCase
    {
        AudioClip GetSe(SeType seType);
    }
}