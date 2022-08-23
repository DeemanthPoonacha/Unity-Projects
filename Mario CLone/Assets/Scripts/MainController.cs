using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public Sprite playImg;
    public Image pauseButton;
    public Sprite pauseImg;
    public GameObject quitButton;
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlayScene");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = (Time.timeScale==0f)?1f:0f;
        pauseButton.sprite =(pauseButton.sprite==playImg)?pauseImg:playImg ;
        quitButton.SetActive(!(quitButton.activeSelf));
    }
}
