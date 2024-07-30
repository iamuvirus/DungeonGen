namespace GenDLib
{
    public class Area
    {
        public int PositionX { get; set; }
        public int PositionX1 => PositionX + Width;
        public int PositionY { get; set; }
        public int PositionY1 => PositionY + Height;
        public int Width { get; set; }
        public int Height { get; set; }

        public CellType CellType { get; set; }
    }

    public enum CellType
    {
        None = 0,
        Room,
        Hall
    }
}
