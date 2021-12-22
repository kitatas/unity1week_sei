using Sei.Main.Data.Entity;
using UniRx;

namespace Sei.Main.Domain.UseCase
{
    public sealed class GameStateUseCase
    {
        private readonly GameStateEntity _gameStateEntity;
        private readonly ReactiveProperty<GameState> _gameState;

        public GameStateUseCase(GameStateEntity gameStateEntity)
        {
            _gameStateEntity = gameStateEntity;
            _gameState = new ReactiveProperty<GameState>(_gameStateEntity.Get());
        }

        public IReadOnlyReactiveProperty<GameState> gameState => _gameState;

        public void SetState(GameState state)
        {
            _gameStateEntity.Set(state);
            _gameState.Value = _gameStateEntity.Get();
        }
    }
}