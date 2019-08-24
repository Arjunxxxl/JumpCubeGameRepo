using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTile : MonoBehaviour
{
    [Header("Collision Data")]
    public GameObject[] exceptions;
    public GameObject collidingObj;

    private void OnTriggerEnter(Collider other)
    {
        if(!other)
        {
            return;
        }

        collidingObj = other.gameObject;
        if(collidingObj.tag == "forceField")
        {
            foreach(GameObject o in exceptions)
            {
                if(other.gameObject == o)
                {
                    return;
                }
            }

            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "forceField")
        {
            foreach (GameObject o in exceptions)
            {
                if (other.gameObject == o)
                {
                    return;
                }
            }

            other.gameObject.SetActive(false);
        }
    }
}
