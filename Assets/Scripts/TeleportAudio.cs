using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAudio : MonoBehaviour
{
    public AudioSource teleportAudio;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            teleportAudio.Play();
        }
    }
}
