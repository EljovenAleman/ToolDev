using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ObjectSnapper : EditorWindow
{
    [Range(0,10)]
    float gridSize;

    public List<float> gridRawValues = new List<float>();

    public List<Vector3> grid1 = new List<Vector3>();
    public List<Vector3> grid2 = new List<Vector3>();


    [MenuItem("CustomExtensions/Snapper")]
    public static void OpenWindow()
    {
        GetWindow<ObjectSnapper>();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        gridSize = EditorGUILayout.FloatField("Size", gridSize);
        GUILayout.EndHorizontal();

        if(GUILayout.Button("Snap Selection"))
        {
            SnapSelection();
        }
    }

    private void SnapSelection()
    {
        for(int i = 50; i>0; i--)
        {
            gridRawValues.Add(-i * gridSize);            
        }

        for (int i = 0; i < 50; i++)
        {
            gridRawValues.Add(i * gridSize);
        }

        Debug.Log(gridRawValues.Count);

        AssingVectorValues();

        DrawGrid();

        
        
        foreach (var selectedObject in Selection.gameObjects)
        {
            selectedObject.transform.position = selectedObject.transform.position.Round();
        }
    }

    private void DrawGrid()
    {
        for(int i = 0; i<200; i++)
        {
            Debug.DrawLine(grid1[i], grid2[i]);
        }
    }

    private void AssingVectorValues()
    {        

        for(int i=99; i>0; i--)
        {
            var vectorStart = new Vector3(gridRawValues[0], 0, gridRawValues[i]);
            var vectorEnd = new Vector3(gridRawValues[99], 0, gridRawValues[i]);

            grid1.Add(vectorStart);
            grid2.Add(vectorEnd);
        }

        for(int i = 99; i>0; i--)
        {
            var vectorStart = new Vector3(gridRawValues[i], 0, gridRawValues[99]);
            var vectorEnd = new Vector3(gridRawValues[i], 0, gridRawValues[0]);

            grid1.Add(vectorStart);
            grid2.Add(vectorEnd);
        }
        

        
    }
    
}

public static class Vector3Extension
{
    public static Vector3 Round( this Vector3 v)
    {
        v.x = Mathf.Round(v.x);
        v.y = Mathf.Round(v.y);        
        v.z = Mathf.Round(v.z);

        return v;
    }
}
