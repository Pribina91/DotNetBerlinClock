using BerlinClock.Model;

namespace BerlinClock.Services.TimeFormatter
{
    public interface ITimeFormatter
    {
        string GetFormattedStringBlock(TimeHolder time);
    }
}
