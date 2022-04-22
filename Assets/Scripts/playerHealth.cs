using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int clawrenceCurrentLives = 3;
    public int clawrenceMaxLives = 3;

    // GAME OVER CONTROLLER
    [SerializeField] gameOverController gameOverScript;



    // ANIMATION FOR PASS OUT
    [SerializeField] private Animator playerAnimation;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(clawrenceCurrentLives <= 0)
        {
            gameOverScript.isClawrencePassedOut = true;
            playerAnimation.SetBool("isPassedOut", true);
        }
    }
}
