using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


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

        GUILayout.Label("Grid Size");
        gridSize = EditorGUILayout.Slider(gridSize, 0.1f, 5);

        GUILayout.EndHorizontal();

        if(GUILayout.Button("Snap Selection"))
        {
            SnapSelection();
        }

        if(GUILayout.Button("Show Grid"))
        {
            ShowGrid();
        }
    }

    private void SnapSelection()
    {        
        CalculateValues();

        ShowGrid();
                        
        foreach (var selectedObject in Selection.gameObjects)
        {
            //selectedObject.transform.position = selectedObject.transform.position.Round();

            selectedObject.transform.position = GetTheNearestPosition(selectedObject.transform.position);
        }
    }

    private Vector3 GetTheNearestPosition(Vector3 position)
    {
        position.x = GetNearestInRawValues(position.x);

        return new Vector3();
    }

    private float GetNearestInRawValues(float x)
    {
        float closest = 0;
        if(x == 0)
        {
            closest = 0;
        }
        else if(x < 0)
        {
            for (int i = 0; i < gridRawValues.Count; i++)
            {
                if(gridRawValues[i]<0)
                {
                    closest = Math.Max(gridRawValues[i] + x, gridRawValues[i + 1] + x);                                        
                }
            }
        }

        return closest;
        
    }

    private void ShowGrid()
    {
        CalculateValues();

        DrawGrid();
    }


    private void CalculateValues()
    {
        AssingRawValues();
        AssingVectorValues();

    }

    private void AssingVectorValues()
    {
        grid1.Clear();
        grid2.Clear();

        for (int i = 19; i > 0; i--)
        {
            var vectorStart = new Vector3(gridRawValues[0], 0, gridRawValues[i]);
            var vectorEnd = new Vector3(gridRawValues[19], 0, gridRawValues[i]);

            grid1.Add(vectorStart);
            grid2.Add(vectorEnd);
        }

        for (int i = 19; i > 0; i--)
        {
            var vectorStart = new Vector3(gridRawValues[i], 0, gridRawValues[19]);
            var vectorEnd = new Vector3(gridRawValues[i], 0, gridRawValues[0]);

            grid1.Add(vectorStart);
            grid2.Add(vectorEnd);
        }

        Debug.Log(grid1.Count);
    }

    private void AssingRawValues()
    {
        gridRawValues.Clear();

        for (int i = 10; i > 0; i--)
        {
            gridRawValues.Add(-i * gridSize);
        }

        for (int i = 0; i < 10; i++)
        {
            gridRawValues.Add(i * gridSize);
        }

        Debug.Log(gridRawValues.Count);
    }

    private void DrawGrid()
    {        
        for(int i = 0; i<38; i++)
        {
            Debug.DrawLine(grid1[i], grid2[i]);
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
