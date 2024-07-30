namespace DGenLib
{
    internal interface IDungeonGenerator
    {
        public sbyte[,] Field { get; set; }
        public List<Room> Rooms { get; set; }
        public DungeonGenerationData dungeonGenerationData { get; set; }
        public void Generate();

    }
}
