using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Transform teleportTarget1;
    public GameObject thePlayer;
    public AudioSource teleportAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            thePlayer.transform.position = teleportTarget1.transform.position;
            teleportAudio.Play();
        }
    }

}