// See https://aka.ms/new-console-template for more information
using DGenLib;

var genData = new DungeonGenerationData()
{
    Height = 50,
    Width = 50,
    RoomCount = 2,
};

while (true)
{
    var dgen = new DungeonGenerator();
    dgen.Generate(genData);


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
    Console.Clear();
}
