using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ObjectSnapperGridVizualizer
{
    ObjectSnapper obs = new ObjectSnapper();

    void OnValidate()
    {
        //Handles.DrawLine(obs.grid1[0], obs.grid2[0]);
    }

}
