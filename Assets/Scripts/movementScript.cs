using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementScript : MonoBehaviour
{
    

    // LANE CHANGING
    [SerializeField] int desiredLane = 2;
    [SerializeField] int currentLane = 2;
    private float laneDistance = 6f;


    // PLAYER MOVEMENT
    Rigidbody rigidBody;
    int speed = 10;

    //ANIMATION
    [SerializeField] private Animator playerAnimation;

    //PLAYER HEALTH
    [SerializeField] playerHealth playerHealthScript;


    // TO DETECT IF ROLLING TO DESTROY DESTRUCTABLE OBJS
    bool isRolling = false;

    //PARTICLE EFFECTS
    [SerializeField] private ParticleSystem destroyParticles;
    [SerializeField] private ParticleSystem waterParticles;
    [SerializeField] private ParticleSystem babyLobsterParticles;


    //FEET PARTICLE SYSTEM
    [SerializeField] private ParticleSystem footWater1;
    [SerializeField] private ParticleSystem footWater2;
    [SerializeField] private ParticleSystem footWater3;
    [SerializeField] private ParticleSystem footWater4;
    [SerializeField] private ParticleSystem footWater5;
    [SerializeField] private ParticleSystem footWater6;


    //SCENE CONROLLER USED TO DETECT IF CLAWRENCE IN THE WATER
    [SerializeField] scoreController sceneContollerScript;

    //FOR CLAWRENCE BEING PASSED OUT & ENABLING PASSED OUT UI
    [SerializeField] Image GameOverPassedOut;
    //
    [SerializeField] gameOverController gameOverScipt;


    //UI ELEMENT FOR WINNING, 
    [SerializeField] Image gameWonUI;


    //TO CHANGE ANIMATION CONTROLLERS FROM RUNNING TO CLAWRENCE GOING HOME
    [SerializeField] RuntimeAnimatorController clawrence;
    [SerializeField] RuntimeAnimatorController clawrenceGoingHome;

    //AUDIO FOR CLAWRENCE RUNNING IN SAND
    [SerializeField] AudioSource audioSourceRunning;
    [SerializeField] AudioSource audioSource;               //For one shots
    [SerializeField] AudioClip clawrenceRunning;
    [SerializeField] AudioClip clawrenceRoll;


    //UPDATE BABY LOBSTER SAVED SCRIPT ON SCORE SCRIPT
    [SerializeField] scoreController scoreScript;


    //TO DETECT IF SPINNING FOR BABY LOBSTERS
    bool isSpinning = false;


    // AUDIO FOR COLLISION AND EATING
    [SerializeField] AudioClip bonk;
    [SerializeField] AudioClip eating;
    [SerializeField] AudioClip yay;
    [SerializeField] AudioClip sadBabyLobster;


    //TESTING
    Vector3 moveVector;
    Vector3 targetPosition;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Vector3 startingPosition = transform.position;
        this.gameObject.GetComponent<Animator>().runtimeAnimatorController = clawrence;

    }
      
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.GetComponent<Animator>().runtimeAnimatorController = clawrenceGoingHome;
        }

        if(Input.GetKeyDown(KeyCode.A) && rigidBody.velocity.x < 1)
        {
            moveLane(0);
        }
        else if (Input.GetKeyDown(KeyCode.D) && rigidBody.velocity.x > -1)
        {
            moveLane(1);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {           
            roll();
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            startSpin();
        }
         targetPosition = transform.position.z * Vector3.forward;


    }

    private void FixedUpdate()
    {
        if (desiredLane < currentLane)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane > currentLane)
        {
            targetPosition += Vector3.right * laneDistance;
        }
    
        //moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = 0;
        moveVector.z = 0;

        rigidBody.MovePosition(transform.position + moveVector * Time.deltaTime);
    }


    void moveLane(int direction)            // 0 for left 1 for right
    {
        if(direction == 1)
        {
            desiredLane += 1;
        }
        else if (direction == 0)
        {
            desiredLane -= 1;
        }
        desiredLane = Mathf.Clamp(desiredLane, 1, 3);
   
    }

    void roll()
    {
        playerAnimation.SetBool("roll", true);
        isRolling = true;
        audioSource.PlayOneShot(clawrenceRoll);
    }

    void endRoll()
    {
        playerAnimation.SetBool("roll", false);
        isRolling = false;
    }

    void startRoll()
    {

    }

    void startSpin()
    {
        playerAnimation.SetBool("spin", true);
        isSpinning = true;
    }

    void endSpin()
    {
        playerAnimation.SetBool("spin", false);
        isSpinning = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("destructable") && isRolling)
        {
            destroyParticles.Play();
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(bonk);
        }
        else
        if (collision.gameObject.CompareTag("destructable") && !isRolling)
        {
            destroyParticles.Play();
            Destroy(collision.gameObject);
            playerHealthScript.clawrenceCurrentLives--;
            audioSource.PlayOneShot(bonk);
        }
        else
        if (collision.gameObject.CompareTag("nonDestructable"))
        {
            destroyParticles.Play();
            Destroy(collision.gameObject);
            playerHealthScript.clawrenceCurrentLives--;
            audioSource.PlayOneShot(bonk);
        }
        else
        if (collision.gameObject.CompareTag("foodForClawrence"))
        {
            destroyParticles.Play();
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(eating);
            if (playerHealthScript.clawrenceCurrentLives < playerHealthScript.clawrenceMaxLives)
            {
                playerHealthScript.clawrenceCurrentLives++;
            }            
        }
        else
        if(collision.gameObject.CompareTag("babyLobster") && isSpinning)
        {
            babyLobsterParticles.Play();
            scoreScript.babyLobsterSaved++;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(yay);
        }
        else
        if(collision.gameObject.CompareTag("babyLobster"))
        {
            audioSource.PlayOneShot(sadBabyLobster);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("startLegParticles"))
        {
            audioSourceRunning.Stop();
            this.gameObject.GetComponent<Animator>().runtimeAnimatorController = clawrenceGoingHome;
            footWater1.Play();
            footWater2.Play();
            footWater3.Play();
            footWater4.Play();
            footWater5.Play();
            footWater6.Play();
            playerAnimation.SetLayerWeight(1, 1f);
        }
        else
        if (other.gameObject.CompareTag("detectionForWinning"))
        {            
            waterParticles.Play();
        }       
    }

    public void endGamePassedOut()
    {
        gameOverScipt.isClawrencePassedOut = true;
        footWater1.Stop();
        footWater2.Stop();
        footWater3.Stop();
        footWater4.Stop();
        footWater5.Stop();
        footWater6.Stop();
    }

    public void endGameWon()                                                    // MEANT TO BE CALLED WITH CLAWRENCEGOINGHOME  -- NEED TO BE CHANGED
    {
        sceneContollerScript.gameWonOver = true;
        gameWonUI.gameObject.SetActive(true);
        scoreScript.updateScores();
    }

    public void clawrencePassedOutUI()
    {
        GameOverPassedOut.gameObject.SetActive(true);
        scoreScript.updateScores();
        audioSourceRunning.Stop();
        scoreScript.clawrencePassedOut = true;
    }
}
