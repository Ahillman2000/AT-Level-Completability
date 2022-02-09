using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Objective MainObjective;
    [SerializeField] private Objective targetObjective;

    void Start()
    {
        /*Objective[] objectives = ObjectiveManager.BFSMethod(MainObjective, targetObjective);

        foreach(Objective o in objectives)
        {
            Debug.Log(o.name); 
        }*/
    }

    void Update()
    {
        
    }
}
