using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBolt : MonoBehaviour
{
    //public GameObject Shot;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shot")
        {
            Destroy(other.gameObject);
        }
    }
}
