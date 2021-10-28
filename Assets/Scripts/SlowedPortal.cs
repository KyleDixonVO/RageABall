using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class SlowedPortal : MonoBehaviour
{   
    
    public Transform teleportTarget1;
    public GameObject thePlayer;
    public AudioSource teleportAudio;
    public Rigidbody PlayerBody;
    static bool PlayPortal = false;
    private static System.Timers.Timer portalDowntime;
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
            PlayerBody.velocity = new Vector3(0,0,0);
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
