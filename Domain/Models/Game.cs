namespace TrainGame.Domain.Models
{
    public class Game
    {
        public string id { get; }
        public int score { get; set; }
        public List<int> previousQuestions = new List<int>();
        public Question currentQuestion {get; set; }
        
        public Game(string gameId)
        {
            id = gameId;
            currentQuestion = new Question();
        }

        public int IncreaseScore() 
        {
            return ++score;
        }

    }
}