using TrainGame.Domain.Models;

namespace TrainGame.Domain.Services
{
    public interface IGameService
    {
        Game CreateGame();
        Question NextQuestion(string gameId);
        bool CheckAnswer(string gameId, string answer);
    }
}

