namespace DGenLib
{
    public class RoomGenerator
    {
        public int MinWidth = 10;
        public int MaxWidth = 20;
        public int MinHeight = 5;
        public int MaxHeight = 20;

        public Room Generate(int width, int height)
        {
            var random = new Random();
            var size = GetSize();

            int x = random.Next(0, width - 1 - size.X);
            int y = random.Next(0, height - 1 - size.Y);

            return new Room()
            {
                Height = size.X,
                Width = size.Y,
                Position = new Point(x, y)
            };
        }

        public Point GetSize()
        {
            var random = new Random();
            int width = random.Next(MinWidth, MaxWidth);
            int height = random.Next(MinHeight, MaxHeight);

            return new Point(width, height);
        }
    }
}