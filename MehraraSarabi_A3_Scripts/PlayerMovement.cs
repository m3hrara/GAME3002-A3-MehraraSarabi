using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject UIPanel = null;
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private Rigidbody rb = null;
    [SerializeField]
    private CapsuleCollider capsuleCollider = null;
    [SerializeField]
    private DoorController door1 = null;
    [SerializeField]
    private DoorController door2 = null;

    public float moveSpeed = 20;
    public float maxSpeed = 13; // horizontal
    private Vector3 currentVel;
    private float jumpForce = 300;
    private float distanceToFloor;
    private int jumpNum = 0;
    public int direction = 1;
    private int key = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        distanceToFloor = capsuleCollider.bounds.extents.y;
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToFloor + 0.2f);
    }
    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            RespawnPlayer();
        }
        if (collision.gameObject.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            key++;
            door1.key = key;
            door2.key = key;
        }
        if (collision.gameObject.tag == "Door1")
        {
            if (key == 1)
                door1.canOpen = true;
            else
            {
                UIPanel.SetActive(true);
                StartCoroutine("DelayUI");
            }
        }
        if (collision.gameObject.tag == "Door2")
        {
            if (key == 2)
                door2.canOpen = true;
            else
            {
                UIPanel.SetActive(true);
                StartCoroutine("DelayUI");
            }
        }

    }
    IEnumerator DelayUI()
    {
        yield return new WaitForSeconds(3f);
        UIPanel.SetActive(false);
    }
    void RespawnPlayer()
    {
        rb.transform.position = spawnPos.position;
        rb.velocity = Vector3.zero;
    }
    void Update()
    {
        float inputVal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(rb.velocity.x + Time.deltaTime * moveSpeed * inputVal, rb.velocity.y, 0);
        if (inputVal < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1 * Mathf.Abs(transform.localScale.z));
        }
        else if (inputVal > 0)
        {
            direction = 1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
        }

        // Clamp the horizontal velocity.

        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            if (rb.velocity.x > maxSpeed)
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
            else
                rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
        }


        // If the player has jumped 0 or 1 time, allow another jump.

        if (Input.GetKeyDown("space") && jumpNum < 1)
        {
            if (jumpNum == 0)
            {
                rb.AddForce(new Vector3(jumpForce *0.2f * direction, jumpForce), ForceMode.Impulse);
            }
            else if(jumpNum == 1)
            {
                rb.AddForce(new Vector3(jumpForce * 0.15f * direction, jumpForce * 0.8f), ForceMode.Impulse);
            }
            jumpNum++;
        }
        if(isGrounded())
        {
            jumpNum = 0;
        }
    }
}
