using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreController : MonoBehaviour
{

    //INCREASE SCORE
    [SerializeField]
    private int score;
    private int increaseScoreIncrement = 1;
    private float timeBetweenIncrease = 0.1f;
    private float timer;

    // WINNING SCORE
    private int winningScore = 1000;


    // TEXT MESH
    [SerializeField] TextMeshProUGUI scoreUI;

    //PASSED OUT UI
    [SerializeField] Image GameOverPassedOut;

    // GAME OVER CONTROLLER
    [SerializeField] gameOverController gameOverScript;

    // GAME WON / LOST ENEABLE UI AND STOP MOVEMENT
    public bool gameWonOver = false;


    //SEA AUDIO
    [SerializeField] AudioSource seaAudio;
    [SerializeField] AudioClip seaAudioClip;
    private bool seaAudioPlayed = false;


    //BABY LOBSTER SAVED SCORE
    public int babyLobsterSaved;


    //UI ELEMENTS TO UPDATE SCORE / BABY LOBSTERS ETC
    [SerializeField] TextMeshProUGUI TotalscoreGameWon;
    [SerializeField] TextMeshProUGUI TotalbabyLobstersGameWon;
    [SerializeField] TextMeshProUGUI TotalscoreGameLost;
    [SerializeField] TextMeshProUGUI TotalbabyLobstersGameLost;


    //used to stop spawning of objects

    public bool maxPointsReached = false;
    public bool clawrencePassedOut = false;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (!maxPointsReached && !clawrencePassedOut)
        {
            if (timer >= timeBetweenIncrease)
            {
                score += increaseScoreIncrement;
                timer = 0;
            }
            scoreUI.text = "score : " + score.ToString();

        }


        if (score >= winningScore)
        {
            gameOverScript.isClawrenceHome = true;
            if (seaAudioPlayed == false)
            {
                playSeaAudio();
            }
        }

        if (score >= winningScore)
        {
            maxPointsReached = true;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(clawrencePassedOut);
        // timer += Time.deltaTime;
        //if (!maxPointsReached || !clawrencePassedOut)
        //{
        //    if (timer >= timeBetweenIncrease)
        //    {
        //        score += increaseScoreIncrement;
        //        timer = 0;
        //    }
        //    scoreUI.text = "score : " + score.ToString();

        //}


        //if (score >= winningScore)
        //{
        //    gameOverScript.isClawrenceHome = true;
        //    if(seaAudioPlayed == false)
        //    {
        //        playSeaAudio();
        //    }
        //}

        //if(score >= winningScore)
        //{
        //    maxPointsReached = true;
        //}


       
    }

    void playSeaAudio()
    {
        seaAudioPlayed = true;
        seaAudio.PlayOneShot(seaAudioClip);

    }

    public void updateScores()
    {
        TotalscoreGameLost.text = "Score : " + score.ToString();
        TotalbabyLobstersGameLost.text = "Baby Lobsters saved : " + babyLobsterSaved.ToString();


        TotalscoreGameWon.text = "Score : " + score.ToString();
        TotalbabyLobstersGameWon.text = "Baby Lobsters saved : " + babyLobsterSaved.ToString();
    }
}
