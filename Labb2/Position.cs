using System;
namespace Labb2
{
    public class Position
    {
        private double x;
        private double y;

        public double X { get => x; set => x = value < 0 ? 0 : value; }
        public double Y { get => y; set => y = value < 0 ? 0 : value; }

        //Constructor
        public Position(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        //Methods
        public double Length()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public bool Equals(Position p)
        {
            return X.Equals(p.X) && Y.Equals(p.Y);
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        //Operator matipulation
        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length().Equals( p2.Length()))
                return p1.X > p2.X;

            return p1.Length() > p2.Length();
        }

        public static bool operator <(Position p1, Position p2)
        {
            return p2 > p1;
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Position operator -(Position p1, Position p2)
        {
            double x = p1.X - p2.X;
            double y = p1.Y - p2.Y;

            if (x < 0)
            {
                x *= -1;
            }
            if (y < 0)
            {
                y *= -1;
            }

            return new Position(x, y);
        }

        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
