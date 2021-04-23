using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform = null;
    [SerializeField]
    private Vector3 springArmOffset;
    private float deltaT = 0.5f;

    void FixedUpdate()
    {
        Vector3 cameraPos = playerTransform.position + springArmOffset;
        Vector3 lerpPos = Vector3.Lerp(playerTransform.position, cameraPos, deltaT);
        transform.position = lerpPos;
    }
}
