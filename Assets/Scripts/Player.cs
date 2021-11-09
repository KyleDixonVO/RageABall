using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public GameObject WinTextObject;
    public TextMeshProUGUI LoseTextObject;
    public GameObject ControlMenuObject;
    public TextMeshProUGUI StopsRemaining;
    public AudioSource deathAudio;
    public AudioSource pickUpAudio;
    public AudioSource wallAudio;
    public AudioSource slowAudio;
    public float speedCap = 10f;
    public Rigidbody rigidbody;
    public Transform Spawn;
    public GameObject thePlayer;
    private bool PlayerMoveForward;
    private bool PlayerMoveBack;
    private bool PlayerMoveLeft;
    private bool PlayerMoveRight;
    private int Deaths;
    private int CoinsRemaining;
    static bool usePrecisionStop = false;
    static int precisionStopsRemaining = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        CoinsRemaining = 16;
        SetScoreText();
        Deaths = 0;
        SetLoseText();
        WinTextObject.SetActive(false);
        this.gameObject.SetActive(true);
        thePlayer.transform.position = Spawn.transform.position;
        ControlMenuObject.SetActive(true);
        SetPrecsionStopText();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (ControlMenuObject.activeInHierarchy == true)
            { 
                ControlMenuObject.SetActive(false); 
            }
            
            else
            {
                ControlMenuObject.SetActive(true);
            }
        }
       

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMoveForward = true;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMoveBack = true;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerMoveRight = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerMoveLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            usePrecisionStop = true;
        }

    }
    void SetScoreText()
    {
        ScoreText.text = "Coins Remaining:" + CoinsRemaining.ToString();
        if (CoinsRemaining <= 0)
        {
            WinTextObject.SetActive(true);
        }
    }

    void SetLoseText()
    {
        LoseTextObject.text = "Deaths:" + Deaths.ToString();
    }

    void SetPrecsionStopText()
    {
        StopsRemaining.text = "Slows Remaining: " + precisionStopsRemaining.ToString();
    }
    private void FixedUpdate()
    {
        if (usePrecisionStop == true)
        {
            if (precisionStopsRemaining > 0)
            {
                slowAudio.Play();
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);   
                precisionStopsRemaining--;
                SetPrecsionStopText();
            }
            usePrecisionStop = false;
        }

        if (PlayerMoveForward == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 5, ForceMode.VelocityChange);
            PlayerMoveForward = false;
        }

        if (PlayerMoveBack == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.back * 5, ForceMode.VelocityChange);
            PlayerMoveBack = false;
        }

        if (PlayerMoveLeft == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 5, ForceMode.VelocityChange);
            PlayerMoveLeft = false;
        }

        if (PlayerMoveRight == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 5, ForceMode.VelocityChange);
            PlayerMoveRight = false;
        }
        if (rigidbody.velocity.magnitude > 40f)
        {
            rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            rigidbody.velocity = rigidbody.velocity.normalized * Time.deltaTime * 30f;
            //rigidbody.AddRelativeForce(rigidbody.velocity);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpAudio.Play();
            CoinsRemaining = CoinsRemaining - 1;
            SetScoreText();

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            
            Deaths = Deaths + 1;
            SetLoseText();
            thePlayer.transform.position = Spawn.transform.position;
            deathAudio.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            wallAudio.Play();     
        }
    }
}

