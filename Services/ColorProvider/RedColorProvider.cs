namespace BerlinClock.Services.ColorProvider
{
    public class RedColorProvider : BaseColorProvider, IColorProvider
    {
        public string GetColor(bool enabled)
        {
            return enabled ? "R" : EmptySymbol;
        }
    }
}
