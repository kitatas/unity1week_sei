using Sei.Main.Data.Entity;
using UniRx;

namespace Sei.Main.Domain.UseCase
{
    public sealed class TimeUseCase
    {
        private readonly TimeEntity _timeEntity;
        private readonly ReactiveProperty<float> _time;

        public TimeUseCase(TimeEntity timeEntity)
        {
            _timeEntity = timeEntity;
            _time = new ReactiveProperty<float>(_timeEntity.Get());
        }

        public IReadOnlyReactiveProperty<float> time => _time;

        public void Update(float deltaTime)
        {
            _timeEntity.Add(deltaTime);
            _time.Value = _timeEntity.Get();
        }
    }
}