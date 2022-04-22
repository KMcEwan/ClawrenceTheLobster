using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] Image lives;
    private float lifeAmount;


    [SerializeField] playerHealth clawrenceHealthController;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeAmount = (float)clawrenceHealthController.clawrenceCurrentLives;
        lifeAmount = lifeAmount / clawrenceHealthController.clawrenceMaxLives;
        lives.fillAmount = lifeAmount;
    }
}
