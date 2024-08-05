namespace GenDLib
{
    public class DungeonGenerator
    {
        public Dungeon Generate()
        {
            //Создать пустое
            var dungeon = new Dungeon();

            //Заполнить комнатами
            var roomGenerator = new RoomGenerator(/*параметры генератора*/);
            roomGenerator.Generate(dungeon);

            //Между комнатами заполнить лабиринтом
            var hallwayGenerator = new HallwayGenerator(/*параметры генератора*/);
            hallwayGenerator.Generate(dungeon);

            //Связать комнаты и лабаиринт
            throw new NotImplementedException();
        }
    }
}
