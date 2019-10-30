using BerlinClock.Model;

namespace BerlinClock.Services.InputParser
{
    public interface IInputParser
    {
        TimeHolder ParseInputString(string input);
    }
}
