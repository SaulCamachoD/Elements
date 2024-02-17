using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playOnePlayer()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void playTwoPlayers()
    {
        SceneManager.LoadScene("MainGame 1");
    }

    public void exit()
    {
        Debug.Log("Salio Del Juego");
        Application.Quit();
    }
}
