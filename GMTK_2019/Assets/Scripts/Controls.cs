using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    // it may make more sense to do "[SerializeField]" as i dont think this needs to be called from anywhere. we just need to edit the feilds from 

    public float startSpeed;        // Start speed for scenario
    public float maxSpeed;          // Our maximum speed allowed.
    public float currentSpeed;      // Current Speed;
    public float maxThrust;         // How much force to apply (Forward).
    public float currentThrust;     // Breaks.
    public float Yaw;
    public float RollAmount;
    public float minThrust;
    public float liftMultplier;
    public float lift;
    public float thrustChangeAmount;
    public bool GameStart;
    public bool GamePaused;
    public bool GameOver;
    public bool gameCountdown;
    private float nextActionTime = 0.0f;
    public float countdownPeriod = 1f;
    public float gameStartTime = 3f;
    public GameObject startpanel;
    public GameObject readySetGoPanel;
    public Text timerText;
    public GameObject pausepanel;
    public GameObject resultspanel;
    public GameObject mainCamera;
    public GameObject world;
    public float timeCheck;



    private Rigidbody rb;           // Our Rigidbody.

    void Start()
    {
        Time.timeScale = 1;
        GameStart = false;
        gameCountdown = false;
        GamePaused = false;
        GameOver = false;
        rb = GetComponent<Rigidbody>();        // Gets the players Rigidbody.
        startpanel.SetActive(true);
    }

    public void restart()
    {
        Time.timeScale = 1;
        GameStart = false;
        gameCountdown = false;
        GamePaused = false;
        GameOver = false;
        startpanel.SetActive(true);
        resultspanel.SetActive(false);
        pausepanel.SetActive(false);
    }

    public void startCountdown()
    {
        gameCountdown = true;
        readySetGoPanel.SetActive(true);
        //spawn player repaired, new position, new rotation (y)
        world.GetComponent<SpawnWorld>().SpawnGame();
    }

    void FixedUpdate()
    {
        if (gameCountdown)
        {
            if (gameStartTime <= 0)
            {
                GameStart = true;
                gameCountdown = false;
                readySetGoPanel.SetActive(false);
            }
            gameStartTime = gameStartTime - Time.unscaledDeltaTime;
            timerText.text = gameStartTime.ToString("0");
            timeCheck = Time.unscaledDeltaTime;
            
        }

        //calculate gameplay forces
        if (GameStart && !GamePaused && !GameOver)
        {
            //refresh current speed
            currentSpeed = Mathf.Abs(rb.velocity.z) + Mathf.Abs(rb.velocity.x);

            //Thrust Forward
            rb.AddRelativeForce(Vector3.forward * currentThrust);

            rb.transform.Rotate(0, Yaw / 10, 0, Space.Self);

            changeThrust();
            turningInputs();
            if (Input.GetKey(KeyCode.Escape)){
                PauseGame();
            }

            //test spawn mechanic
            if (Input.GetKey(KeyCode.Space))
            {
                world.GetComponent<SpawnWorld>().SpawnGame();
            }

        }

        //escape from pause
        if (!GamePaused)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                ResumeGame();
            }
        }

        //if plane is slow on ground end game
        if ( rb.transform.position.y <= 7 && currentSpeed < 4 && GameStart)
        {

            endGame();

        }
    }

    public void ReadySetGo()
    {

    }

    public void StartGame()
    {
        GameStart = true;
        GameOver = false;
        Time.timeScale = 1;
        rb.velocity = new Vector3(0, 0, startSpeed);
        RollAmount = rb.transform.rotation.x;
    }

    public void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        Time.timeScale = 1;
        pausepanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void turningInputs()
    {
        if (GameStart && !GamePaused && !GameOver)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Yaw = Mathf.Clamp(Yaw + Input.GetAxis("Horizontal"), -5f, -.3f);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Yaw = Mathf.Clamp(Yaw + Input.GetAxis("Horizontal"), -2f, -.3f);
            }
            else
            {
                Yaw = -1f;
            }
        }
    }



    private void changeThrust()
    {
        if (GameStart && !GamePaused && !GameOver)
        {
            if (currentSpeed < maxSpeed)
            {
                if (currentThrust < maxThrust)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        //Apply Accelleration
                        currentThrust += thrustChangeAmount;

                    }
                }

            }

            // can add later if needs to just start off the back remove the get key down for W
            if (currentSpeed > 0)
            {
                if (currentThrust > minThrust)
                {
                    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        //Apply Accelleration
                        currentThrust -= thrustChangeAmount;

                    }
                }
            }
        }
    }
    
    public void endGame()
    {
        GameOver = true;
        resultspanel.GetComponentInChildren<calcScore>().GetScore();
        resultspanel.SetActive(true);
        GameStart = false;
        //stop object
        //populate scoring metrics
        // game UI set active false
    }
}
