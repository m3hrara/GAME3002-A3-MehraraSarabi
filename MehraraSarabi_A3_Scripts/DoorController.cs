using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private GameObject boxCollider = null;
    public int key = 0;
    public int door = 0;
    public bool canOpen = false;
    private float m_fTargetPos = -90f;
    private float m_fSpring = 10000f;
    private float m_fDamper = 60f;
    private HingeJoint m_hingeJoint = null;
    private JointSpring m_jointSpring;

    void Start()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
        m_hingeJoint.useSpring = true;

        m_jointSpring = new JointSpring();
        m_jointSpring.spring = m_fSpring;
        m_jointSpring.damper = m_fDamper;

        m_hingeJoint.spring = m_jointSpring;
    }

    void Update()
    {
        // If the key number and the door number match, open the door.
        if (Input.GetKeyDown(KeyCode.E) && key == door && canOpen)
        {
            boxCollider.SetActive(false);
            m_jointSpring.targetPosition = m_fTargetPos;
        }
        m_hingeJoint.spring = m_jointSpring;
    }
}