using TrainGame.Domain.Models;

namespace TrainGame.Domain.Services
{
    public interface IRandomGeneratorService
    {
        string RandomString(int size, bool lowerCase = false);
        int RandomInt(int min, int max);
    }
}

