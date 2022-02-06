using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected Double jump");

            CharacterControllerScript player = other.GetComponent<CharacterControllerScript>();
            player.hasDoubleJump = true;

            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
