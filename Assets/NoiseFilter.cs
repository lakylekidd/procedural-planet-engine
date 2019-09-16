using UnityEngine;

public class NoiseFilter
{
    NoiseSettings settings;
    Noise noise = new Noise();

    public NoiseFilter(NoiseSettings settings)
    {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point)
    {
        // Retrieve a value from the point and convert to range 0 - 1
        float noiseValue = (noise.Evaluate(point) + 1) * .5f;
        return noiseValue;
    }
}
