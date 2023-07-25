using TrainGame.Domain.Models;
using TrainGame.Domain.Services;

namespace TrainGame.Services 
{
    public class GameService : IGameService
    {
        private Dictionary<string, Game> _liveGames;
        private IRandomGeneratorService _randomGenerator;

        public GameService()
        {
            _liveGames = new Dictionary<string, Game>();
            _randomGenerator = new RandomGeneratorService();
        }
        
        public GameService(IRandomGeneratorService randomGeneratorService)
        {
            _liveGames = new Dictionary<string, Game>();
            _randomGenerator = randomGeneratorService;
        }

        public bool CheckAnswer(string gameId, string answer)
        {
            //Needs question format to really be written
            //Get game object
            //Get current question in game obejct
            //check answer
            //if correct send object containing score and next question? Or Just score and user clicks a button to get next question?
            //if incorrect redirect to game over screen? Or send incorrect and user clicks button?
            Game game;
            if (_liveGames.TryGetValue(gameId, out game)) 
            {
                if (String.Equals(answer, game.currentQuestion.answer, StringComparison.OrdinalIgnoreCase))
                {
                    game.IncreaseScore();
                    return true;
                } else {
                    return false; //??
                }
            }
            else
            {
                throw new ArgumentException("gameId doesn't correspond to a game");
            }
        }

        public Game CreateGame()
        {
            string id = CreateId();
            Game game = new Game(id);
            _liveGames.Add(id, game);
            return game;
        }

        public string NextQuestion(string gameId)
        {
            //Needs DB stuff to actually be written
            //Given a game ID this function will select a question from the DB that isn't already contained in the Games' previous questions list
            Game game;
            if (_liveGames.TryGetValue(gameId, out game)) 
            {
                //actually get next question
            }
            else
            {
                throw new ArgumentException("gameId doesn't correspond to a game");
            }
            
            throw new NotImplementedException();
        }


        private string CreateId()
        {
            string id = _randomGenerator.RandomString(10);
            while (_liveGames.ContainsKey(id)) {
                id = _randomGenerator.RandomString(10);
            }
            return id;
        }
    }
}