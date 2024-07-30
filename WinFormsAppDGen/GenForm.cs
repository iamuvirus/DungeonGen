using DGenLib;

namespace WinFormsAppDGen
{
    public partial class GenForm : Form
    {
        public GenForm()
        {
            InitializeComponent();
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            var genData = new DungeonGenerationData()
            {
                Height = 30,
                Width = 30,
                MinRoomCount = 7,
            };
            var random = new Random();
            var dgen = new DungeonGenerator(genData);
            do
            {
                dgen = new DungeonGenerator(genData);
                dgen.Generate();
            } while (dgen.Rooms.Count < random.Next(6, 12));



            var cellSize = 25;
            int rows = dgen.Field.GetUpperBound(0) + 1;
            int columns = dgen.Field.GetUpperBound(1) + 1;
            var bitmap = new Bitmap(rows * cellSize, columns * cellSize);
            var graph = Graphics.FromImage(bitmap);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    graph.FillRectangle(Brushes.White, new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize));
                    if (dgen.Field[i, j] == 1)
                    {
                        graph.FillRectangle(Brushes.Black, new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize));
                    }
                    if (dgen.Field[i, j] == 2)
                    {
                        graph.FillRectangle(Brushes.Gray, new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize));
                    }

                }

            }
            pictureBox1.Image = bitmap;
        }

        public void Draw()
        {



        }
    }
}
