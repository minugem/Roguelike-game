using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject destoryVFX; //VFX after destoryed
    private PickupSpawner pickupSpawner; //Reference item drop script
    public static Destruct Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
        pickupSpawner = GetComponent<PickupSpawner>();
    }

    public void DestoryObject() 
    {
        if (destoryVFX != null) { 

            Instantiate(destoryVFX,transform.position, transform.rotation);
        }

        pickupSpawner.DropItems();//Drop item

        //Destory current obj
        Destroy(gameObject);
    }
}
