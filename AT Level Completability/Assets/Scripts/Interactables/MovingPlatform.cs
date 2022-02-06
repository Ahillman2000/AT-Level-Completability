using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    float direction = 1;

    [SerializeField] float waitTime;

    [SerializeField] float speed = 1f;

    void Start()
    {
        this.transform.position = startPos.position;
    }

    void Update()
    {
        if(this.transform.position == startPos.position)
        {
            StartCoroutine(Wait(1));
        }
        else if (this.transform.position == endPos.position)
        {
            StartCoroutine(Wait(0));
        }
    }

    IEnumerator Wait(float _direction)
    {
        yield return new WaitForSeconds(waitTime);
        direction = _direction;
    }

    private void FixedUpdate()
    {
        if (direction == 1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, endPos.position, speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, startPos.position, speed * Time.deltaTime);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Parented");
            other.transform.parent = this.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Unparented");
            other.transform.parent = null;
        }
    }*/
}
