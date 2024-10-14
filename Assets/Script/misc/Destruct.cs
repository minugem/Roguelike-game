using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject destoryVFX; //VFX after destoryed
    private PickupSpawner pickupSpawner; //Reference item drop script

    private void Awake() 
    {
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
