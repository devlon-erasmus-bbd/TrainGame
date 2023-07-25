using TrainGame.Domain.Models;
using TrainGame.Domain.Services;

namespace TrainGame.Services 
{
    public class RandomGeneratorService : IRandomGeneratorService
    {
        private readonly Random _random = new Random();

        public int RandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            //https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
            var builder = new System.Text.StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}