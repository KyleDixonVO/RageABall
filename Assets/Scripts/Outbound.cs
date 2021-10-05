using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outbound : MonoBehaviour
{
    public Transform teleportTarget2;
    public GameObject thePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thePlayer.transform.position = teleportTarget2.transform.position;
        }
    }
}
