using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas howToPlayCanvas;
    private void Awake()
    {
        howToPlayCanvas.enabled = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void HowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        howToPlayCanvas.enabled = false;
    }
}
