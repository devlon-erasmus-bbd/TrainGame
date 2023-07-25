namespace TrainGame.Domain.Models
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public int highScore { get; set; }

        public User()
        {
            userName = " ";
        }
    }
}