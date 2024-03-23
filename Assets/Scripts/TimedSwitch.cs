using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSwitch : Switch
{
    [SerializeField] private float _duration;

    private Coroutine _coroutine;


    protected override void ActivateSwitch()
    {
       if(_active == false)
        {
            _active = true;
            if(_coroutine == null)
            {
                SwitchActivation?.Invoke(_active);
                _coroutine = StartCoroutine(DeactivateObjects(_duration));
            }
        }
    }

    IEnumerator DeactivateObjects(float time)
    {
        yield return new WaitForSeconds(time);
        _active = false;
        SwitchActivation?.Invoke(_active);
        _coroutine = null;
    }
}

