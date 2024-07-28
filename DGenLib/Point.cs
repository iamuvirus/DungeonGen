namespace DGenLib
{
    public struct Point : IEquatable<Point>
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        public static bool operator !=(Point lhs, Point rhs)
        {
            return !(lhs == rhs);
        }

        public override readonly bool Equals(object? other)
        {
            if (!(other is Point))
            {
                return false;
            }

            return Equals((Point)other);
        }

        public readonly bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override readonly int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() << 2;
        }

        public int GetIndex()
        {
            return 1000 * Y + X;
        }
    }
}
