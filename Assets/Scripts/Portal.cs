using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Portal : MonoBehaviour
{
    private static System.Timers.Timer portalDowntime;
    public Transform teleportTarget1;
    public GameObject thePlayer;
    public AudioSource teleportAudio;
    static bool PlayPortal = false;
    // Start is called before the first frame update
    void Start()
    {
        portalDowntime = new System.Timers.Timer(5000);
        portalDowntime.Elapsed += PortalTimer;
        portalDowntime.AutoReset = true;
        portalDowntime.Enabled = true;
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