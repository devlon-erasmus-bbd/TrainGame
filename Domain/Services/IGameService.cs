using TrainGame.Domain.Models;

namespace TrainGame.Domain.Services
{
    public interface IGameService
    {
        Game CreateGame();
        string NextQuestion(string gameId);
        bool CheckAnswer(string gameId, string answer);
    }
}

