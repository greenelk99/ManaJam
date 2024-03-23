using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _pauseButton;

    public void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);
    }

    public void LoadScene(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

}
