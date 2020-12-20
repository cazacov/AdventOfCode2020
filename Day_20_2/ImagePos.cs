namespace Day_20_2
{
    public class ImagePos
    {
        public Image Image;
        public int Orientation;
        public ImagePos[] Neighbors;
        public int X;
        public int Y;
        public ImagePos(Image image, int orientation)
        {
            this.Image = image;
            this.Orientation = orientation;
            this.Neighbors = new ImagePos[4];
            for (int i = 0; i < 4; i++)
            {
                Neighbors[i] = null;
            }
        }

        public override string ToString()
        {
            return $"{Image.Id} - {Orientation}";
        }

        public void SetNeighbor(ImagePos other, int direction)
        {
            var map = new[] { 2, 3, 0, 1 };
            var mapx = new[] { -1, 0, 1, 0 };
            var mapy = new[] { 0, 1, 0, -1 };

            this.Neighbors[direction] = other;
            other.Neighbors[map[direction]] = this;

            other.X = this.X + mapx[direction];
            other.Y = this.Y + mapy[direction];
        }

    }
}