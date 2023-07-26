namespace TrainGame.Domain.Models
{
    public class Game
    {
        public string id { get; }
        public int score { get; set; }
        public List<Tuple<int, int>> previousQuestions = new List<Tuple<int, int>>();
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