using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runAnimation : MonoBehaviour
{

    //ANIMATION
    [SerializeField] private Animator playerAnimation;
    void Start()
    {
        playerAnimation.SetBool("running", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
