namespace DGenLib
{
    public class DungeonGenerator : IDungeonGenerator
    {
        public sbyte[,] Field { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public DungeonGenerationData dungeonGenerationData { get; set; }
        public DungeonGenerator(DungeonGenerationData dungeonGenerationData)
        {
            this.dungeonGenerationData = dungeonGenerationData;
        }
        public void Generate()
        {
            Field = new sbyte[this.dungeonGenerationData.Height, this.dungeonGenerationData.Width];
            var roomGenerator = new RoomGenerator();

            var count = 10000;
            while (count > 0)
            {
                count--;
                var room = roomGenerator.Generate(dungeonGenerationData.Width, dungeonGenerationData.Height);
                var intersect = Intersects(room);
                if (intersect == false)
                {
                    Rooms.Add(room);
                }
            }

            FillField();


            GeneratePaths();
        }

        private void GeneratePaths()
        {
            int rows = Field.GetUpperBound(0) + 1;
            int columns = Field.GetUpperBound(1) + 1;

            int x = 0;
            int y = 0;

            HashSet<Tuple<int, int>> needConnectPoints = new HashSet<Tuple<int, int>>();
            needConnectPoints.Add(new Tuple<int, int>(x, y));

            while (needConnectPoints.Count > 0)
            {
                var point = HashSetUtilities.GetAndRemoveRandomElement(needConnectPoints);

                x = point.Item1;
                y = point.Item2;

                Field[y, x] = 2;

                Connect(Field, x, y);
                AddVisitPoints(Field, needConnectPoints, x, y);
            }



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
            var random = new Random();

            var AX1 = roomA.Position.X;
            var AY1 = roomA.Position.Y;
            var AX2 = roomA.Position.X + roomA.Width;
            var AY2 = roomA.Position.Y + roomA.Height;

            foreach (var roomB in Rooms)
            {
                var offset = random.Next(2, 5);
                var BX1 = roomB.Position.X - offset;
                var BY1 = roomB.Position.Y - offset;
                var BX2 = roomB.Position.X + roomB.Width + offset;
                var BY2 = roomB.Position.Y + roomB.Height + offset;

                var intersect = AX1 < BX2 && AX2 > BX1 && AY1 < BY2 && AY2 > BY1;
                if (intersect)
                {
                    return true;
                }
            }
            return false;
        }

        private void Connect(sbyte[,] maze, int x, int y)
        {
            int[,] directions = new int[,]
            {
            {-1, 0 },
            { 1, 0 },
            { 0,-1 },
            { 0, 1 }
            };

            ShuffleUtility.Shuffle(directions);

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                // Нужно направление умножать на 2
                // чтоб оставлять стенку размером в 1 ячейку
                int neighborX = x + directions[i, 0] * 2;
                int neighborY = y + directions[i, 1] * 2;

                if (MazeHelper.IsRoad(maze, neighborX, neighborY))
                {
                    int connectorX = x + directions[i, 0];
                    int connectorY = y + directions[i, 1];
                    maze[connectorY, connectorX] = 2;

                    return;
                }
            }
        }

        private void AddVisitPoints(sbyte[,] maze, HashSet<Tuple<int, int>> points, int x, int y)
        {
            if (MazeHelper.IsPointInMaze(maze, x - 2, y) && MazeHelper.IsRoad(maze, x - 2, y) == false)
                points.Add(new Tuple<int, int>(x - 2, y));

            if (MazeHelper.IsPointInMaze(maze, x + 2, y) && MazeHelper.IsRoad(maze, x + 2, y) == false)
                points.Add(new Tuple<int, int>(x + 2, y));

            if (MazeHelper.IsPointInMaze(maze, x, y - 2) && MazeHelper.IsRoad(maze, x, y - 2) == false)
                points.Add(new Tuple<int, int>(x, y - 2));

            if (MazeHelper.IsPointInMaze(maze, x, y + 2) && MazeHelper.IsRoad(maze, x, y + 2) == false)
                points.Add(new Tuple<int, int>(x, y + 2));
        }
    }
}