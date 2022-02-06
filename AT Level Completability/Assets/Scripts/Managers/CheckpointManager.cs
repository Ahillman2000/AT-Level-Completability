using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject spawnPoint;
    private GameObject currentCheckpoint;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
            SetCurrentCheckpoint(spawnPoint);
        }
    }

    public GameObject GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
    public void SetCurrentCheckpoint(GameObject _checkpoint)
    {
        currentCheckpoint = _checkpoint;
    }
}
