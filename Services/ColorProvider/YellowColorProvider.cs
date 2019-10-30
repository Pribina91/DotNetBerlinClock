namespace BerlinClock.Services.ColorProvider
{
    public class YellowColorProvider : BaseColorProvider,IColorProvider
    {
        public string GetColor(bool enabled)
        {
            return enabled ? "Y" : EmptySymbol;
        }
    }
}
