using Microsoft.Xna.Framework;

namespace Arriba.Core.Geometrics;

public class RectangleD
{
    public double X { get; set; }
    public double Y { get; set;}
    public double W { get; set;}
    public double H { get; set;}
    
    public float fX => (float)X;
    public float fY => (float)Y;
    public float fW => (float)W;
    public float fH => (float)H;

    public int iX => (int)X;
    public int iY => (int)Y;
    public int iW => (int)W;
    public int iH => (int)H;

    public Vector2 TopLeft
    {
        get => new(fX, fY);
        set { X = value.X; Y = value.Y; }
    }
    
    public Vector2 BottomRight
    {
        get => new(fX + fW, fY + fH);
    }

    public Vector2 Center => new(fX + fW/2, fY + fH/2);

    public Rectangle ToInt()
    {
        return new Rectangle
        {
            X = iX,
            Y = iY,
            Height = iH,
            Width = iW,
        };
    }
}