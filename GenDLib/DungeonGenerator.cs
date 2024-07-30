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
            var hallGenerator = new HallwayGenerator(/*параметры генератора*/);
            hallGenerator.Generate(dungeon);

            //Связать комнаты и лабаиринт
            throw new NotImplementedException();
        }
    }
}
