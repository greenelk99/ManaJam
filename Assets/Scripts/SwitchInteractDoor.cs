using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteractDoor : MonoBehaviour
{

    [SerializeField] private Switch _switch;

    private void Awake()
    {
        _switch.SwitchActivation += OpenDoor;
    }


    private void OpenDoor(bool active)
    {
        gameObject.SetActive(!active);
    }
}
