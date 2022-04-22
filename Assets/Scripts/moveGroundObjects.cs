using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGroundObjects : MonoBehaviour
{
    //MOVE OBJECTS
   private int startingMoveSpeed = -12;
   private int wonMoveSpeed = -5;                 // speed for when game is won, but not reached the sea
   private int gameOverWonSpeed = 0;              // speed for then game is won and clawrence is in the sea
    [SerializeField] int sceneMovementSpeeds;


    // GAME OVER SCRIPT
    GameObject sceneController;
    [SerializeField] gameOverController gameOverScript;

    // GAME OVER WON SCRIPT
    [SerializeField] scoreController scoreControllerScript;



    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("sceneController");
        gameOverScript = sceneController.GetComponent<gameOverController>();
        scoreControllerScript = sceneController.GetComponent<scoreController>();

        sceneMovementSpeeds = startingMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scoreControllerScript.gameWonOver);
        //Debug.Log(gameOverScript.isClawrenceHome);
        if (gameOverScript.isClawrenceHome && !scoreControllerScript.gameWonOver)
        {
            sceneMovementSpeeds = wonMoveSpeed;
        }
        else
        if(scoreControllerScript.gameWonOver || gameOverScript.isClawrencePassedOut)
        {
            sceneMovementSpeeds = gameOverWonSpeed;
        }
            transform.Translate(Vector3.forward * Time.deltaTime * sceneMovementSpeeds, Space.World);
     
    }
}
