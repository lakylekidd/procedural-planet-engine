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
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;
        for (int i = 0; i < settings.numLayers; i++)
        {
            // Calculate the noise value 
            float v = noise.Evaluate(point * frequency + settings.center);
            noiseValue += (v + 1) * .5f * amplitude;
            // Determine the frequency and persistence for each layer
            frequency *= settings.roughness;
            amplitude *= settings.persistence;
        }
        noiseValue = Mathf.Max(0, noiseValue - settings.minValue);
        return noiseValue * settings.strength;
    }
}
