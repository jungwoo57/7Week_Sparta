
public static class AngleCalculator 
{
    public static float NormalizeAngle360(float angle)
    {
        angle = angle % 360;
        if (angle < 0) angle += 360;
        return angle;
    }
}
