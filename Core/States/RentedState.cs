using LocadoraDigital.Core.Entities;

namespace LocadoraDigital.Core.States
{
    public class RentedState : IGameState
    {
        public string Status => "ALUGADO";

        public void Rent(Game game)
        {
            throw new InvalidOperationException("O jogo já está alugado.");
        }

        public void Return(Game game)
        {
            game.State = new AvailableState();
            //Lógica de devolução a ser implementada
        }
    }
}
