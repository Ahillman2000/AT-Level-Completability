using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parentable"))
        {
            Debug.Log("Player Parented");
            this.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Unparented");
            this.transform.parent = null;
        }
    }
}
