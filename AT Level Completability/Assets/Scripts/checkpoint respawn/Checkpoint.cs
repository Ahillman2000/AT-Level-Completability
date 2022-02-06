using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    CheckpointManager checkpointManager;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player            = GameObject.FindGameObjectWithTag("Player");
        checkpointManager = player.GetComponent<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Updated checkpoint");
            checkpointManager.SetCurrentCheckpoint(this.gameObject);
        }
    }
}
