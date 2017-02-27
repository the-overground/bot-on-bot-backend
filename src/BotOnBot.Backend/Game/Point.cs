namespace BotOnBot.Backend.Game
{
    internal struct Point
    {
        internal int X, Y;

        internal Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }

        public static Point operator -(Point left, Point right)
        {
            return new Point(left.X - right.X, left.Y - right.Y);
        }

        public override string ToString()
        {
            return $"{{X: {X}, Y: {Y}}}";
        }
    }
}
