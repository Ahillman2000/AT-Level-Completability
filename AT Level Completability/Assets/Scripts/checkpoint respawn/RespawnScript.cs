using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    CheckpointManager checkpointManager;
    [SerializeField] float deathDepth = 0;

    GameObject player;
    Vector3 playerInitSpot;

    void Start()
    {
        checkpointManager = this.GetComponent<CheckpointManager>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerInitSpot = player.transform.position;
        //Debug.Log("inital transform = " + playerInitSpot);

        if(checkpointManager.spawnPoint != null)
        {
            this.transform.position = checkpointManager.spawnPoint.transform.position;
        }
    }

    public void Respawn()
    {
        if(checkpointManager.GetCurrentCheckpoint() == null)
        {
            Debug.Log("Player respawned at spawn");
            this.transform.position = playerInitSpot;

            /*if (checkpointManager.spawnPoint != null)
            {
                this.transform.position = checkpointManager.spawnPoint.transform.position;
            }
            else
            {
                this.transform.position = playerInitSpot.position;
            }*/
        }
        else
        {
            Debug.Log("Player respawned at last checkpoint");
            this.transform.position = checkpointManager.GetCurrentCheckpoint().transform.position;
        }
    }
    
    void Update()
    {
        if (this.transform.position.y < deathDepth || Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
}
