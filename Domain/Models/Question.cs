namespace TrainGame.Domain.Models
{
    public class Question //Idea is that we populate this object based on what's in the DB
    {
        public int id { get; set; }
        public string text { get; set; }
        public string answer {get; set; }

        public Question()
        {
            text = "Is your mom heavier than a train?";
            answer = "NO";
        }
    }
}