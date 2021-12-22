using Sei.Common.Data.Entity;

namespace Sei.Main.Data.Entity
{
    public sealed class GameStateEntity : BaseEntity<GameState>
    {
        public GameStateEntity()
        {
            Init(GameState.Ready);
        }
    }
}