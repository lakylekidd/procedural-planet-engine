using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    private Planet planet;
    private Editor shapeEditor;
    private Editor colorEditor;

    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                planet.GeneratePlanet();
            }
        }
        
        // Begin drawing the color and spahe settings editor items
        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout, ref colorEditor);
    }

    private void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
    {
        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (foldout)
                {
                    // Update the existing editor
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();
                }

                // Only update the changed settings
                // if there is a change in the inspector
                if (check.changed)
                    onSettingsUpdated?.Invoke();
            }            
        }        
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }

    
}
