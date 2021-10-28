using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Outbound : MonoBehaviour
{
    public Transform teleportTarget2;
    public GameObject thePlayer;
    public AudioSource teleportAudio;
    private static System.Timers.Timer portalDowntime;
    static bool PlayPortal = false;

    static void Start()
    {
        portalDowntime = new System.Timers.Timer(5000);
        portalDowntime.Elapsed += PortalTimer;
        portalDowntime.AutoReset = true;
        portalDowntime.Enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thePlayer.transform.position = teleportTarget2.transform.position;
            if (PlayPortal == true)
            {
                teleportAudio.Play();
                PlayPortal = false;
            }
        }
    }

    static void PortalTimer(object source, ElapsedEventArgs e)
    {
        PlayPortal = true;
    }


}
