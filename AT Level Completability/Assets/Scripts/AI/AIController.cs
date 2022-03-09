using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private ObjectiveManager objectiveManager;

    private NavMeshAgent agent;
    NavMeshPath navMeshPath;

    bool problemDebugged = false;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();
    }

    void Update()
    {
        Move();
    }

    private bool AtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Move()
    {
        GameObject objectiveGameObject = objectiveManager.GetCurrentObjective().gameObject;

        if (agent.CalculatePath(objectiveGameObject.transform.position, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
        {
            //move to target
            Debug.Log("path is valid");
            agent.SetDestination(objectiveGameObject.transform.position);
        }
        else
        {
            if(problemDebugged == false)
            {
                //Fail condition here
                //Debug.LogWarning("path is invalid");

                //UnityEditor.EditorGUIUtility.PingObject(objectiveGameObject);
                //UnityEditor.Highlighter.Highlight("Hierarchy", objectiveGameObject.name);

                Debug.LogWarning("The current objective: " + objectiveGameObject.name + " is unable to be reached due to an invalid path", objectiveGameObject);

                problemDebugged = true;
            }
        }
    }
}
