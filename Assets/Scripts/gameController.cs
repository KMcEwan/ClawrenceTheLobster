using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    AudioSource[] audioSources;

    //FOR PAUSING
    private bool isPaused = false;

    //FOR ENABLING PAUSE UI
    [SerializeField] Image pausedUI;


    //FOR THE INITAL 'WHAT TO DO' OVERLAY
    [SerializeField] GameObject whatToDO;

    private void Start()
    {
        Time.timeScale = 0f;
        audioSource.Play();
        audioSources = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name != "sceneController")                                       // to keep background music playing while sound effects are paused
            {
                audioSources[i].Pause();
            }

        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    void resumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausedUI.gameObject.SetActive(false);

        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name != "sceneController")                                                              
            {
                audioSources[i].UnPause();
            }

        }
    }

    void pauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausedUI.gameObject.SetActive(true);

        for(int i = 0; i < audioSources.Length; i++)
        {
            if(audioSources[i].name != "sceneController")                                       // to keep background music playing while sound effects are paused
            {
                audioSources[i].Pause();
            }
            
        }
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void quitGame()
    {
        SceneManager.LoadScene(0);
    }



    public void startGame()
    {
        Time.timeScale = 1f;
        whatToDO.gameObject.SetActive(false);
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].name != "sceneController")
            {
                audioSources[i].UnPause();
            }

        }
    }

}
