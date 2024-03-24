using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFloorPlate : Switch
{

    private int _objectsOnSwitch;


    private void OnTriggerEnter(Collider other)
    {
        _objectsOnSwitch = _objectsOnSwitch + 1;
        ActivateSwitch();
    }


    private void OnTriggerExit(Collider other)
    {
        _objectsOnSwitch= _objectsOnSwitch - 1;
        ActivateSwitch();
    }

    protected override void ActivateSwitch()
    {
       if( _objectsOnSwitch == 0 && _active == true)
        {
            _active = false;

            SwitchActivation(_active);
        }
       else if(_objectsOnSwitch > 0 && _active == false)
        {
            _active = true;
            SwitchActivation(_active);
        }
    }

}
