namespace Arriba.Core;

public class RangeValue
{
    public readonly float Min;
    public readonly float Max;

    public RangeValue(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public RangeValue(float value)
    {
        Max = Min = value;
    }

    public float Random()
    {
        return Min + RngGenerator.Get() * (Max - Min);
    }
    
    public int RandomInt()
    {
        return (int)Random();
    }

    public override string ToString()
    {
        return $"{Min}-{Max}";
    }
}