using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJumpVizualizer : MonoBehaviour
{
    [SerializeField] Cube cube;
    Vector3 previousCubePosition;
    public float time;
    Vector3 landingPoint;

    
    private void OnDrawGizmosSelected()
    {
        if (cube.isJumping == false)
        {
            previousCubePosition = cube.transform.position;
            for (float i = 0; i < 2; i += 0.01f)
            {
                Gizmos.DrawLine(GetTrajectoryPoint(i, cube.transform.position), GetTrajectoryPoint(i + 0.01f, cube.transform.position));
            }
        }
        else
        {
            for (float i = 0; i < 2; i += 0.01f)
            {
                Gizmos.DrawLine(GetTrajectoryPoint(i, previousCubePosition), GetTrajectoryPoint(i + 0.01f, previousCubePosition));
            }
        }

        /*landingPoint = new Vector3(cube.transform.position.x, 0, cube.transform.position.z) +
            (new Vector3(1, 1, 0) * cube.jumpForce * time) +
            0.5f * Physics.gravity * (time * time);*/

        //Gizmos.DrawWireCube(landingPoint, new Vector3(1.1f, 0, 1.1f));        
    }

    Vector3 GetTrajectoryPoint(float time, Vector3 guideVector)
    {
        return new Vector3(guideVector.x, 0, guideVector.z) +
            (new Vector3(1, 1, 0) * cube.jumpForce * time) +
            0.5f * Physics.gravity * (time * time); ;
    }
}
