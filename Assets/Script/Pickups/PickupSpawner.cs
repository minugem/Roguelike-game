using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Generate Item
/// </summary>
public class PickupSpawner : MonoBehaviour
{
    public PropPrefab[] propPrefabs; //Store different item prefab
    public static PickupSpawner Instance { get; private set; }

    //Start generate item
    public void Awake()
    {
        Instance = this;
    }
    public void DropItems()
    {
        foreach (var propPrefab in propPrefabs)
        {
            if (Random.Range(0f, 100f) <= propPrefab.dropPercentage)//according to the percentage
            {
                Instantiate(propPrefab.prefab, transform.position, Quaternion.identity);
            }
        }
    }
}

[System.Serializable] 
public class PropPrefab
{
    public GameObject prefab; //dropitem prefab

    [Range(0f, 100f)] public float dropPercentage; //drop percentage 0-100%
}
