using UnityEngine;

namespace Sei.Main.Domain.UseCase
{
    public sealed class InputUseCase
    {
        public Vector2 GetInputDirection()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }
    }
}