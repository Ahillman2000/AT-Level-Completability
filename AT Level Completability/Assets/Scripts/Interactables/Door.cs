using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject requiredKey;

    private bool open = false;
    private Quaternion targetRotation;
    [SerializeField] float openCloseSpeed = 0.5f;

    void Start()
    {
        targetRotation = this.transform.rotation * Quaternion.Euler(0, -90, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            KeyManager keyManager = other.GetComponent<KeyManager>();
            if(keyManager.HasKey(requiredKey))
            {
                keyManager.RemoveKey(requiredKey);
                open = true;
            }
        }
    }

    public void Open()
    {
        // Dampen towards the target rotation
        if (this.transform.rotation != targetRotation)
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, openCloseSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if(open)
        {
            Open();
        }
    }
}
