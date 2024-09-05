using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.States
{
    public class AvailableState : IGameState
    {
        public string Status => "LIVRE";

        public void Rent(Game game)
        {
            game.State = new RentedState();
            // Lógica de aluguel a ser implementada
        }

        public void Return(Game game)
        {
            throw new InvalidOperationException("O jogo já está disponível.");
        }
    }
}
