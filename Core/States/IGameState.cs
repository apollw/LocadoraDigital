using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.States
{
    public interface IGameState
    {
        void Rent(Game game);
        void Return(Game game);
        string Status { get; }
    }
}
