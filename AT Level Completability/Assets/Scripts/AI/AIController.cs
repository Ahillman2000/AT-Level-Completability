using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    //[SerializeField] private Camera cam;

    //[SerializeField] private GameObject targetObj;
    //private Transform targetTransform;

    [SerializeField] private ObjectiveManager objectiveManager;
    //[SerializeField] private GameObject currectObjective;

    private NavMeshAgent agent;
    NavMeshPath navMeshPath;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();
        //targetTransform = targetObj.transform;

        // Set current target location to player's position
        //targetObj.transform.position = this.gameObject.transform.position;
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
        // if there is no current objective use raycast to determine where the agent should move to
        /*if(currectObjective == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(hit.point);
                    targetObj.transform.position = hit.point;
                }
            }
        }
        // if there is a current object then agent move towards it
        else
        {
            targetObj.transform.position = currectObjective.transform.position;
        }*/

        //agent.SetDestination(targetTransform.position);

        GameObject objectiveGameObject = objectiveManager.GetCurrentObjective().gameObject;

        if (agent.CalculatePath(objectiveGameObject.transform.position, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
        {
            //move to target
            Debug.Log("path is valid");
            agent.SetDestination(objectiveGameObject.transform.position);
        }
        else
        {
            //Fail condition here
            Debug.Log("path is invalid");
        }
    }

    /*public GameObject GetCurrentObjective()
    {
        return currectObjective;
    }
    public void SetCurrentObjective(GameObject _currentObjective)
    {
        currectObjective = _currentObjective;
        targetObj.transform.position = currectObjective.transform.position;
    }*/
}
