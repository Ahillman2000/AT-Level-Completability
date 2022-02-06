using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    //[SerializeField] private Transform targetObj;
    [SerializeField] private Vector3 target;

    // [SerializeField] NavMeshAgent agent;
    private NavMeshAgent agent;
    private Rigidbody rb;

    [SerializeField] private GameObject groundCheck;
    [SerializeField] private float groundCheckRadius = 7.5f;
    [SerializeField] float jumpForce = 1.0f;

    void Start()
    {
        target = this.gameObject.transform.position;
        agent = this.GetComponent<NavMeshAgent>();
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        /* if((target != null && target.y > this.gameObject.transform.position.y && IsGrounded()))*/
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        //Debug.Log("AI is grounded = " + IsGrounded());

        RaycastHit rayhit;
        
        return Physics.SphereCast(groundCheck.transform.position, groundCheckRadius, Vector3.down, out rayhit, groundCheckRadius);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.transform.position, groundCheckRadius);
    }


    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
                Debug.Log(hit.transform.position);
            }
        }

       
        /// find a way to fix jump and a way to turn agent off long enough to jump
        if(IsGrounded())
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            agent.enabled = true;
            agent.SetDestination(target);
        }
    }

    private void Jump()
    {
        Debug.Log("Jump!");

        agent.enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = false;

        rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpForce, ForceMode.Impulse);
    }
}
