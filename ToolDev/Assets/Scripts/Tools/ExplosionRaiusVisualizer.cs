using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ExplosionRaiusVisualizer : MonoBehaviour
{
    public ExplosiveBarrel barrel;

    private void OnDrawGizmosSelected()
    {        
        Gizmos.DrawWireSphere(barrel.transform.position, barrel.explosionRadius);        
    }


}
