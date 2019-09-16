using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    private Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated);
    }

    private void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated)
    {
        Editor editor = CreateEditor(settings);
        editor.OnInspectorGUI();
        onSettingsUpdated?.Invoke();
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }

    
}
