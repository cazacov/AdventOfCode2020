namespace Day_20_2
{
    public static class ArrayHelper
    {
        public static long[] RotateBorders(long[] input, int times)
        {
            var result = new long[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = input[(i + input.Length - times) % input.Length];
            }
            return result;
        }

        public static long[] FlipBorders(long[] input)
        {
            var result = new long[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ReverseBits(input[(input.Length - i) % input.Length]);
            }
            return result;
        }

        public static void Flip(bool[,] image)
        {
            var ih = image.GetUpperBound(0) + 1;
            var iw = image.GetUpperBound(1) + 1;

            for (int y = 0; y < ih / 2; y++)
            {
                for (int x = 0; x < iw; x++)
                {
                    var temp = image[y, x];
                    image[y, x] = image[ih - y - 1, x];
                    image[ih - y - 1, x] = temp;
                }
            }
        }

        public static long ReverseBits(long input)
        {
            var result = 0L;
            for (var i = 0; i < 10; i++)
            {
                result |= ((input >> i) & 0x01) << (9 - i);
            }
            return result;
        }

        public static void RotateImage(bool[,] image)
        {
            var ih = image.GetUpperBound(0) + 1;
            var iw = image.GetUpperBound(1) + 1;
            // rotate CCW
            for (int y = 0; y < ih / 2; y++)
            {
                for (int x = 0; x < iw / 2; x++)
                {
                    var temp = image[y, x];
                    image[y, x] = image[x, iw - y - 1];
                    image[x, iw - 1 - y] = image[ih - y - 1, iw - x - 1];
                    image[ih - y - 1, iw - x - 1] = image[ih - x - 1, y];
                    image[ih - x - 1, y] = temp;
                }
            }
        }
    }
}
