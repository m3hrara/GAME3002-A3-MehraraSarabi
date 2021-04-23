using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject winPanel = null;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            winPanel.SetActive(true);
        }
    }
}
