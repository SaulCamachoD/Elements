using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    private HealthDeath HealthDeath;
    private HeatlhDeath2 HeatlhDeath2;




    private void Start()
    {
        HealthDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDeath>();
        HeatlhDeath2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<HeatlhDeath2>();
        HealthDeath.PlayerDeath += ActiveMenu;
        HeatlhDeath2.PlayerDeath += ActiveMenu;


    }

    
    private void ActiveMenu(object sender, EventArgs e)
    {
        gameOverMenu.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
