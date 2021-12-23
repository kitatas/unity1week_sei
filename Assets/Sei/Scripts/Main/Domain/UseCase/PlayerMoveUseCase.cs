using UnityEngine;

namespace Sei.Main.Domain.UseCase
{
    public sealed class PlayerMoveUseCase
    {
        private readonly float _acceleration = 0.5f;
        private readonly Rigidbody2D _rigidbody;

        public PlayerMoveUseCase(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.AddForce(direction - _rigidbody.velocity);
        }
    }
}