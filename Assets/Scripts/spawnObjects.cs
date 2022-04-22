using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    [SerializeField] GameObject[] spawnableObjects;
    Vector3 laneOneSpawnPosition;
    Vector3 laneTwoSpawnPosition;
    Vector3 laneThreeSpawnPosition;

    int laneOneZPos;
    int laneTwoZPos;
    int laneThreeZPos;

    int gameObjectLaneOne;
    int gameObjectLaneTwo;
    int gameObjectLaneThree;

    int spawnStartTime = 3;
    int spawnRepeat = 1;

    //to test if should spawn
    [SerializeField] scoreController scoreControllerScript;

    void Start()
    {

        InvokeRepeating("spawnLaneObjects", spawnStartTime, spawnRepeat);
    }

    void Update()
    {
        
    }

    void spawnLaneObjects()
    {
        if(scoreControllerScript.maxPointsReached == false)
        {

            int laneSpawn = Random.Range(0, 3);

            if(laneSpawn == 0)
            {
                laneOneZPos = Random.Range(20, 30);
                laneOneSpawnPosition = new Vector3(-6, 0, laneOneZPos);

                gameObjectLaneOne = Random.Range(0, spawnableObjects.Length);
                Instantiate(spawnableObjects[gameObjectLaneOne], laneOneSpawnPosition, spawnableObjects[gameObjectLaneOne].transform.rotation);
            }
            else if(laneSpawn == 1)
            {
                laneTwoZPos = Random.Range(20, 30);
                laneTwoSpawnPosition = new Vector3(0, 0, laneTwoZPos);

                gameObjectLaneTwo = Random.Range(0, spawnableObjects.Length);
                Instantiate(spawnableObjects[gameObjectLaneTwo], laneTwoSpawnPosition, spawnableObjects[gameObjectLaneTwo].transform.rotation);
            }
            else
            {
                laneThreeZPos = Random.Range(20, 30);
                laneThreeSpawnPosition = new Vector3(6, 0, laneThreeZPos);            


                gameObjectLaneThree = Random.Range(0, spawnableObjects.Length);
                Instantiate(spawnableObjects[gameObjectLaneThree], laneThreeSpawnPosition, spawnableObjects[gameObjectLaneThree].transform.rotation);
            }


        }
        

    }
}
