using System.Drawing;

namespace MonkeyGame.Model
{
    public class Palm_tree
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        private static readonly Image image = new Bitmap("C:\\Users\\pd01wvj\\Documents\\GitHub\\Shoothemup\\Drones\\Drones\\Resources\\Tree.png");

        public Palm_tree(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y, Width, Height);
        }

        // Collision simple avec un rectangle (ex: joueur)
        public bool CheckCollision(Rectangle rect)
        {
            return GetBounds().IntersectsWith(rect);
        }
    }
}
