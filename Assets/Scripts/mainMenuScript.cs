using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenuScript : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject controlsUI;

    public void quitGame()
    {
        Application.Quit();
    }


    public void loadFullScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void loadSmallScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void displayControls()
    {
        mainMenuUI.gameObject.SetActive(false);
        controlsUI.gameObject.SetActive(true);
    }

    public void backToMain()
    {
        mainMenuUI.gameObject.SetActive(true);
        controlsUI.gameObject.SetActive(false);
    }
}
