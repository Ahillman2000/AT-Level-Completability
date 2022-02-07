using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectiveManager : MonoBehaviour
{
    //Objective[] objectives;
    [SerializeField] private Objective WinObjective;

    GameObject player;
    private AIController controller;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = player.GetComponent<NavMeshAgent>();
        controller = player.GetComponent<AIController>();

        controller.SetCurrentObjective(WinObjective.gameObject);
    }

    void Update()
    {
        /*for (int i = 0; i < WinObjective.GetPrerequesites().Length; i++)
        {
            
        }*/

        /*foreach (var prerequesite in WinObjective.GetPrerequesites())
        {
            if(!prerequesite.Completed())
            {
                controller.SetCurrentObjective(prerequesite.gameObject);
            }
            else
            {

            }
        }

        // if win objective is completed, the game is over
        if (WinObjective.IsCompleted())
        {
            Debug.Log("Win");
        }
        // if the win objective is not completed
        else
        {
            // go through each of its prerequesite objectives
            for (int i = 0; i < WinObjective.GetPrerequesites().Length; i++)
            {
                // if prerequesite is not completed
                if(!WinObjective.GetPrerequesites()[i].IsCompleted())
                {
                    // set controllers current objective to this task
                    controller.SetCurrentObjective(WinObjective.GetPrerequesites()[i].GetComponent<Objective>().gameObject);
                }
                else
                {
                    
                }
            }
            //controller.SetCurrentObjective(WinObjective.GetPrerequesites()[1].GetComponent<Objective>().gameObject);
        }*/



    }
}
