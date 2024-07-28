namespace DGenLib
{
    public class DungeonGenerator
    {
        public sbyte[,] Field { get; private set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public DungeonGenerationData DungeonGenerationData { get; private set; }
        public void Generate(DungeonGenerationData dungeonGenerationData)
        {
            DungeonGenerationData = dungeonGenerationData;
            Field = new sbyte[DungeonGenerationData.Height, DungeonGenerationData.Width];
            var roomGenerator = new RoomGenerator();
            for (int i = 0; i < dungeonGenerationData.RoomCount; i++)
            {
                var intersect = true;

                while (intersect)
                {
                    var room = roomGenerator.Generate(dungeonGenerationData.Width, dungeonGenerationData.Height);
                    intersect = Intersects(room);
                    if (intersect == false)
                    {
                        Rooms.Add(room);
                    }
                }
            }
            FillField();
        }

        public void FillField()
        {
            foreach (var room in Rooms)
            {
                for (int y = room.Position.Y; y < room.Position.Y + room.Height; y++)
                {
                    for (int x = room.Position.X; x < room.Position.X + room.Width; x++)
                    {
                        Field[y, x] = 1;
                    }
                }
            }
        }

        private bool Intersects(Room roomA)
        {
            var AX1 = roomA.Position.X;
            var AY1 = roomA.Position.Y;
            var AX2 = roomA.Position.X + roomA.Width;
            var AY2 = roomA.Position.Y + roomA.Height;

            foreach (var roomB in Rooms)
            {
                var BX1 = roomB.Position.X;
                var BY1 = roomB.Position.Y;
                var BX2 = roomB.Position.X + roomB.Width;
                var BY2 = roomB.Position.Y + roomB.Height;

                var intersect = AX1 < BX2 && AX2 > BX1 && AY1 < BY2 && AY2 > BY1;
                if (intersect)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
