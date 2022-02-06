using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject currectObjective;

    [SerializeField] private GameObject targetObj;
    private Transform targetTransform;

    private NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        targetTransform = targetObj.transform;

        // Set current target location to player's position
        targetObj.transform.position = this.gameObject.transform.position;
    }

    void Update()
    {
        Move();

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("At destination");
                    // set target to null
                }
            }
        }
    }

    private void Move()
    {
        // if there is no current objective use raycast to determine where the agent should move to
        if(currectObjective == null)
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
        }

        agent.SetDestination(targetTransform.position);
    }
}
