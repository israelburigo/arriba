namespace Arriba.Core;

public class RangeValue
{
    public readonly float Min;
    public readonly float Max;

    public RangeValue(float min, float max)
    {
        Min = min;
        Min = max;
    }

    public RangeValue(float value)
    {
        Max = Min = value;
    }

    public float Random()
    {
        return Min + RngGenerator.Get() * (Max - Min);
    }
}