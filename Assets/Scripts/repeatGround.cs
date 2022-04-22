using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatGround : MonoBehaviour
{
    // REPEAT GROUND
    private Vector3 startingPosition;
    private float halfLengthOfGround;


    // GAME OVER SCRIPT
    [SerializeField] gameOverController gameOverScript;

    void Start()
    {
        startingPosition = transform.position;
        halfLengthOfGround = GetComponent<BoxCollider>().size.z / 2;
        //Debug.Log(halfLengthOfGround);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOverScript.isClawrencePassedOut && !gameOverScript.isClawrenceHome)
        {
            //Debug.Log(gameOverScript.isClawrenceHome);
            //Debug.Log(gameOverScript.isClawrencePassedOut);
            if (transform.position.z < startingPosition.z - halfLengthOfGround)
            {
                transform.position = startingPosition;
            }
        }        
    }
}
