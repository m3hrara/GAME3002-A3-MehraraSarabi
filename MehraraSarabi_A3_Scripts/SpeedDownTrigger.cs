using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement = null;

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            playerMovement.moveSpeed = 10f;
            playerMovement.maxSpeed = 10f;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            playerMovement.moveSpeed = 20f;
            playerMovement.maxSpeed = 13f;
        }
    }
}
