namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
