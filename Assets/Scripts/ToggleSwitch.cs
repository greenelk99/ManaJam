using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : Switch
{


    protected override void ActivateSwitch()
    {
        _active = !_active;
        SwitchActivation?.Invoke(_active);
    }
}
