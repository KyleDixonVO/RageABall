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
    public AudioSource deathAudio;
    public AudioSource pickUpAudio;
    public AudioSource wallAudio;
    public float speedCap = 10f;
    public Rigidbody rigidbody;
    public Transform Spawn;
    public GameObject thePlayer;
    private bool PlayerMoveForward;
    private bool PlayerMoveBack;
    private bool PlayerMoveLeft;
    private bool PlayerMoveRight;
    private int Deaths;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        SetScoreText();
        Deaths = 0;
        SetLoseText();
        WinTextObject.SetActive(false);
        this.gameObject.SetActive(true);
        thePlayer.transform.position = Spawn.transform.position;
        ControlMenuObject.SetActive(true);
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
            ControlMenuObject.SetActive(false);
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

    }
    void SetScoreText()
    {
        ScoreText.text = "Score:" + Score.ToString();
        if (Score >= 1600)
        {
            WinTextObject.SetActive(true);
        }
    }

    void SetLoseText()
    {
        LoseTextObject.text = "Deaths:" + Deaths.ToString();
    }
    private void FixedUpdate()
    {
        
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
        if (rigidbody.velocity.magnitude > speedCap)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * speedCap;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpAudio.Play();
            Score = Score + 100;
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

