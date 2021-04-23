using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement = null;
    [SerializeField]
    private Rigidbody playerRigidbody = null;
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            // I realized applying an impulse works better than manipulating the speed factor.
            playerRigidbody.AddForce(new Vector3(playerMovement.direction * 200f, 0, 0), ForceMode.Impulse);
        }
    }
}
