using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectiveManager : MonoBehaviour
{
    Objective[] objectives;

    GameObject player;
    private AIController controller;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = player.GetComponent<NavMeshAgent>();
        controller = player.GetComponent<AIController>();
    }

    void Update()
    {
        
    }
}
