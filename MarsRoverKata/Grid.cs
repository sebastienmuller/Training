namespace MarsRoverKata
{
    public class Grid
    {
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }

        public Grid(int maxWidth, int maxHeight)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
        }
    }
}