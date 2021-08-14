using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Text gameOverText;
    [SerializeField] GameObject enemySpawner;

    private void Awake()
    {
        gameOverCanvas.enabled = false;
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void GameOver(string gameOverInfo)
    {
        gameOverText.text = gameOverInfo;
        gameOverCanvas.enabled = true;
        Destroy(enemySpawner);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
