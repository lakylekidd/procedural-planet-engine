using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private MeshFilter[] meshFilters;
    private Face[] terrainFaces;

    [Range(2, 256)]
    public int resolution = 20;
    public bool makeSphere = true;

    private void Initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new Face[6];

        Vector3[] directions =
        {
            Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back
        };

        for (int i = 0; i < 6; i++)
        {
            // Only if the current face mesh filter does not exist
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            // Create the new face
            terrainFaces[i] = new Face(meshFilters[i].sharedMesh, resolution, directions[i], makeSphere);
        }
    }

    private void GenerateMesh()
    {
        foreach(Face face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    private void OnValidate()
    {
        Initialize();
        GenerateMesh();
    }
}
