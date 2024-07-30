namespace GenDLib
{
    public class Dungeon
    {
        public int Height { get; set; } = 30;
        public int Width { get; set; } = 30;
        public List<Area> Areas = new List<Area>();
    }
}
