using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private bool completed;
    [SerializeField] private Objective[] prerequesites;

    public void CompleteObjective()
    {
        completed = true;
    }

    public bool ObjectiveComplete()
    {
        return completed;
    }
}
