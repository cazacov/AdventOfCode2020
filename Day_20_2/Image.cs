using System;
using System.Collections.Generic;
using Day_20_2;

public class Image
{
    public int Id;    
    public bool[,] Content;
    public List<long[]> Borders = new List<long[]>();

    public Image(List<string> lines)
    {
        this.Id = Int32.Parse(lines[0].Substring(5, 4));
        this.Content = new bool[10,10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                this.Content[i, j] = lines[i + 1][j] == '#';
            }
        }
        this.CalculateBorders();
    }

    protected bool Equals(Image other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Image) obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    private void CalculateBorders()
    {
        var identity = this.GetBorders();
        this.Borders.Add(identity);
        for (int i = 1; i <= 3 ; i++)
        {
            var work = Rotate(identity, i);
            this.Borders.Add(work);
        }

        var flipped = Flip(identity);
        this.Borders.Add(flipped);
        for (int i = 1; i <= 3; i++)
        {
            var work = Rotate(flipped, i);
            this.Borders.Add(work);
        }
    }

    private long[] Rotate(long[] input, int times)
    {
        var result = new long[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            result[i] = input[(i + input.Length - times) % input.Length];
        }
        return result;
    }

    private long[] GetBorders()
    {
        var result = new long[4];
        for (int i = 0; i < 10; i++)
        {
            result[0] |= (this.Content[i, 0] ? 1 : 0) << i;
            result[1] |= (this.Content[9, i] ? 1 : 0) << i;
            result[2] |= (this.Content[9-i, 9] ? 1 : 0) << i;
            result[3] |= (this.Content[0, 9-i] ? 1 : 0) << i;
        }
        return result;
    }

    private long[] Flip(long[] input)
    {
        var result = new long[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            result[i] = ReverseBits(input[(input.Length - i) % input.Length]);
        }
        return result;
    }

    public static long ReverseBits(long input)
    {
        var result = 0L;
        for (int i = 0; i < 10; i++)
        {
            result |= ((input >> i) & 0x01) << (9 - i);
        }
        return result;
    }

    public override string ToString()
    {
        return this.Id.ToString();
    }

    public void RenderAt(int posX, int posY, int orientation, ref bool[,] target)
    {
        var result = new bool[8, 8];
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                result[y, x] = Content[y + 1, x + 1];
            }
        }

        if (orientation > 3)
        {
            ArrayHelper.Flip(result);
        }

        for (int j = 0; j < orientation % 4; j++)
        {
            ArrayHelper.RotateImage(result);
        }

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                target[posY + y, posX + x] = result[y, x];
            }
        }
    }
}