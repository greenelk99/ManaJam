using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNextLevelInterface : MonoBehaviour
{

    [SerializeField] private GameObject _nextLevelMenu;
    [SerializeField] private GameObject _pauseButton;


    private void OnTriggerEnter(Collider other)
    {
        _nextLevelMenu.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

}
