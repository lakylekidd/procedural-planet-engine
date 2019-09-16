using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    private Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout);
    }

    private void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout)
    {
        foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

        if (foldout)
        {
            Editor editor = CreateEditor(settings);
            editor.OnInspectorGUI();
        }
                
        onSettingsUpdated?.Invoke();
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }

    
}
