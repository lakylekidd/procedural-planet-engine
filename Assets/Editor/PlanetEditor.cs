using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    private Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawSettingsEditor(planet.shapeSettings);
        DrawSettingsEditor(planet.colorSettings);
    }

    private void DrawSettingsEditor(Object settings)
    {
        Editor editor = CreateEditor(settings);
        editor.OnInspectorGUI();
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }

    
}
