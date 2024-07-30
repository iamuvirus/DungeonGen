// See https://aka.ms/new-console-template for more information
using DGenLib;




//while (true)
//{
//    Console.Clear();
//    var g = new PrimsMazeGenerator();
//    var dd = g.Generate(100, 100);

//    int rows = dd.GetUpperBound(0) + 1;
//    int columns = dd.GetUpperBound(1) + 1;

//    for (int i = 0; i < rows; i++)
//    {
//        for (int j = 0; j < columns; j++)
//        {
//            Console.Write(dd[i, j] ? ' ' : '0');
//        }
//        Console.WriteLine();
//    }
//    Console.ReadKey();

//}

var genData = new DungeonGenerationData()
{
    Height = 30,
    Width = 30,
    MinRoomCount = 7,
};

while (true)
{
    Console.Clear();
    var dgen = new DungeonGenerator(genData);
    dgen.Generate();
    var random = new Random();
    if (dgen.Rooms.Count < random.Next(6, 12))
    {
        continue;
    }


    int rows = dgen.Field.GetUpperBound(0) + 1;
    int columns = dgen.Field.GetUpperBound(1) + 1;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(dgen.Field[i, j]);
        }
        Console.WriteLine();
    }
    Console.ReadKey();

}
