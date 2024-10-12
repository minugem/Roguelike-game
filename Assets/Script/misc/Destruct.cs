using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destoryVFX; //VFX after destoryed

    public void DestoryObject() 
    {
        if (destoryVFX != null) { 

            Instantiate(destoryVFX,transform.position, transform.rotation);
        }
    //Destory current obj
    Destroy(gameObject);
    }
}
