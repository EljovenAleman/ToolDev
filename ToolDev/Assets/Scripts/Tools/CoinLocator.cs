using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class CoinLocator : MonoBehaviour
{
    List<Coin> coins = new List<Coin>();
    private void OnEnable()
    {
        coins = FindObjectsOfType<Coin>().ToList();
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Coin coin in coins)
        {
            Gizmos.DrawLine(transform.position, coin.transform.position);
        }                
    }
}
