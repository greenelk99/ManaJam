using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

     protected bool _active;

    public Action<bool> SwitchActivation;

    private void OnTriggerEnter(Collider other)
    {
        ActivateSwitch();
       
    }
    protected virtual void ActivateSwitch()
    {
        if (_active == false)
        {
            _active = !_active;
            SwitchActivation?.Invoke(_active);
        }
    }



    public void ResetSwitch()
    {
        _active = false;
    }
}
