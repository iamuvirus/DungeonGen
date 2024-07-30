
namespace DGenLib
{
    public class DungeonGeneratorRectangle : IDungeonGenerator
    {

        public sbyte[,] Field { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public DungeonGenerationData dungeonGenerationData { get; set; }
        public DungeonGeneratorRectangle(DungeonGenerationData dungeonGenerationData)
        {
            this.dungeonGenerationData = dungeonGenerationData;
            Field = new sbyte[dungeonGenerationData.Width, dungeonGenerationData.Height];
        }

        public void Generate()
        {
            var roomGenerator = new RoomGenerator();
            var p0 = 0;
            var random = new Random();
            for (int i = 0; i < dungeonGenerationData.MinRoomCount; i++)
            {
                var room = roomGenerator.Generate(dungeonGenerationData.Width, dungeonGenerationData.Height);
                int offset = random.Next(1, 10);
                room.Position = new Point(p0, 0);
                p0 += room.Width + offset;

                if (p0 >= dungeonGenerationData.Width)
                {
                    break;
                }

                Rooms.Add(room);
                //var intersect = true;

                //while (intersect)
                //{
                //    var room = roomGenerator.Generate(dungeonGenerationData.Width, dungeonGenerationData.Height);
                //    intersect = Intersects(room);
                //    if (intersect == false)
                //    {
                //        Rooms.Add(room);
                //    }
                //}
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
