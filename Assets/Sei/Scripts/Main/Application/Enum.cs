namespace Sei.Main
{
    public enum GameState
    {
        None,
        Ready,
        Main,
        Result,
    }

    public enum ItemTyp
    {
        None,
        Increase,
        Decrease,
    }

    public enum EffectType
    {
        None,
        Destroy,
        ItemPlus,
        ItemMinus,
        Explode,
    }
}