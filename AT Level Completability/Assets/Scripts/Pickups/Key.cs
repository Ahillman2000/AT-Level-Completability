using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Objective objectiveScript;

    private void Start()
    {
        objectiveScript = this.GetComponent<Objective>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //KeyManager keyManager = other.GetComponent<KeyManager>();
            //keyManager.CollectKey(this.gameObject);

            objectiveScript.CompleteObjective();
            Debug.Log("Player collected key");

            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
