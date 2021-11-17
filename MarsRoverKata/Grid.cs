namespace MarsRoverKata
{
    public class Grid
    {
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }

        public List<Coordinate> Obstacles { get; private set; }

        public Grid(int maxWidth, int maxHeight, List<Coordinate> obstacles)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            Obstacles = obstacles;
        }

        public Grid(int maxWidth, int maxHeight) : this(maxWidth, maxHeight, new List<Coordinate>(0))
        {
        }
    }
}