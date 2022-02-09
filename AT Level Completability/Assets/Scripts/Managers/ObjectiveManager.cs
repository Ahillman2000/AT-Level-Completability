using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*public static class ObjectiveManager
{
    static Objective[] objectives;
    static ObjectiveManager()
    {
        objectives = (Objective[]) MonoBehaviour.FindObjectsOfType(typeof(Objective));
    }
    static void ResetObjectives()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].used = false;
        }
    }

    public static Objective[] BFSMethod(Objective start, Objective target)
    {
        Objective final = null;

        // if the starting node is the target then return it
        if(start == target)
        {
            Objective[] objectiveArray = { start };
            return objectiveArray;
        }

        start.parentObjective = null;

        Queue<Objective> queue = new Queue<Objective>();
        // get all child objectives of first node
        Objective[] children = start.childObjectives;

        // add all
        foreach(Objective objective in children)
        {
            objective.parentObjective = start;
            queue.Enqueue(objective);
        }

        // while queue is not empty
        ResetObjectives();
        start.used = true;
        while (queue.Count > 0)
        {
            foreach(Objective obj in queue)
            { MonoBehaviour.print(obj.name); }
            MonoBehaviour.print("next");

            // get the first node of the queue
            Objective o = queue.Dequeue();
            o.used = true;
            // if it is the target make it the final node
            if(o == target)
            {
                final = o;
                break;
            }
            Objective[] c = o.childObjectives;
            foreach(Objective objectiv in c)
            {
                if (objectiv.used) { continue; }
                objectiv.parentObjective = o;
                queue.Enqueue(objectiv);
            }
        }
        // if final is null then no path found
        if(final == null)
        {
            return null;
        }
        // get parent
        Objective parent = final.parentObjective;
        List<Objective> list = new List<Objective>();

        // go back through parent of each node
        while(parent != null)
        {
            list.Add(final);
            final = parent;
            parent = final.parentObjective;
        }

        list.Add(final);
        list.Reverse();
        return list.ToArray();
    }
    //return null;
}
*/

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private Objective MainObjective;
    private Objective currentObjective;

    private void Start()
    {
        currentObjective = MainObjective;
    }

    private void Update()
    {
        // if the objective has sub goals
        /*if (!currentObjective.IsCompleted() && currentObjective.HasChildObjectives())
        {
            Objective[] ObjectivesToSearch = currentObjective.GetChildObjectives();
            int numberOfObjectives = ObjectivesToSearch.Length;
            int objectivesComplete = 0;

            // iterate through sub goals
            for (int i = 0; i < numberOfObjectives; i++)
            {
                // if a sub goal is no complete then make it the new current objective
                if (!ObjectivesToSearch[i].IsCompleted())
                {
                    currentObjective = ObjectivesToSearch[i];
                    break;
                }
                // if a sub goal is complete then record it
                else
                {
                    objectivesComplete++;
                }
                // if all sub goals are complete then trace back up
                if (objectivesComplete == numberOfObjectives || currentObjective.IsCompleted() && !currentObjective.HasChildObjectives())
                {
                    currentObjective = currentObjective.GetParentObjective();
                    break;
                }
                // if all sub goals are complete and the goal has no parent goal then win
                if (objectivesComplete == numberOfObjectives && currentObjective.GetParentObjective() == null)
                {
                    Debug.Log("Win");
                }
            }
        }*/

        Debug.Log("Current objective: " + currentObjective + ", completed status = " + currentObjective.IsCompleted());

        if(currentObjective.IsCompleted() == false)
        {
            if (currentObjective.HasChildObjectives())
            {
                Objective[] ObjectivesToSearch = currentObjective.GetChildObjectives();
                int numberOfObjectives = ObjectivesToSearch.Length /*- 1*/;
                //int objectivesComplete = 0;

                for (int i = 0; i < numberOfObjectives; i++)
                {
                    if(ObjectivesToSearch[i].IsCompleted() == false)
                    {
                        currentObjective = ObjectivesToSearch[i];
                        break;
                    }
                }
            }
        }
        else
        {
            if(currentObjective.HasParentObjective())
            {
                currentObjective = currentObjective.GetParentObjective();
            }
            else
            {
                Debug.Log("WIN");
            }
        }
    }

    public Objective GetCurrentObjective()
    {
        return currentObjective;
    }
}