using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    private HealthDeath HealthDeath;

    private void Start()
    {
        HealthDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDeath>();
        HealthDeath.PlayerDeath += ActiveMenu;
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
