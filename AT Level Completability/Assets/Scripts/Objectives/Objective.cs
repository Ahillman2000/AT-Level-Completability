using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Objective parentObjective;
    public Objective[] childObjectives;

    private bool completed = false;

    public void CompleteObjective()
    {
        completed = true;
    }

    public bool IsCompleted()
    {
        return completed;
    }
}
