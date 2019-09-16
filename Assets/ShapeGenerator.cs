using UnityEngine;

public class ShapeGenerator
{
    private ShapeSettings settings;
    private NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter();
    } 

    public Vector3 CalculatePointOnSphere(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseFilter.Evaluate(pointOnUnitSphere);
        return pointOnUnitSphere * settings.planetRadius * (1 + elevation);
    }
}
