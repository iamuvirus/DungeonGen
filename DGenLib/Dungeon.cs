namespace DGenLib
{
    public class Dungeon
    {
        public sbyte[,] Field { get; private set; } = new sbyte[,] { };
        public Dictionary<int, Room> Rooms { get; private set; } = new Dictionary<int, Room>();
    }
}
