using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player collected key");

            KeyManager keyManager = other.GetComponent<KeyManager>();
            keyManager.CollectKey(this.gameObject);

            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
