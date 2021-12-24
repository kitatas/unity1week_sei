using Sei.Main.Data.Entity;
using UnityEngine;

namespace Sei.Main.Domain.UseCase
{
    public sealed class AccelUseCase
    {
        private readonly float _acceleration = 2.0f;
        private readonly float _deceleration = 1.5f;
        private readonly float _maxAccel = 10.0f;
        private readonly AccelEntity _accelEntity;

        public AccelUseCase(AccelEntity accelEntity)
        {
            _accelEntity = accelEntity;
        }

        public float GetAccel() => _accelEntity.Get();

        public void UpdateAccel(float inputValue, float deltaTime)
        {
            var accel = _accelEntity.Get();
            if (inputValue > 0.0f)
            {
                accel += inputValue * _acceleration * deltaTime;
            }
            else
            {
                accel -= _deceleration * deltaTime;
            }

            _accelEntity.Set(Mathf.Clamp(accel, 0.0f, _maxAccel));
        }
    }
}