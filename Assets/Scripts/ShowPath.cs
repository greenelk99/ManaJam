using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour
{

    [SerializeField] private  Switch _switch;
    [SerializeField] private GameObject _path;
    [SerializeField] private GameObject _hideObjects;

    private void Awake()
    {
        _switch.SwitchActivation += ShowPathing;
    }



    private void ShowPathing(bool active)
    {
        _path.SetActive(active);
        _hideObjects.SetActive(!active);
    }
}
