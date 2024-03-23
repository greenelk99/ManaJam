using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSwitch : Switch
{
   

    public void InteractWithSwitch()
    {
        _active = !_active;
        SwitchActivation?.Invoke(_active);
    }



    private void OnTriggerEnter(Collider other)
    {
       
        Player player = other.GetComponent<Player>();


        if (player != null)
        {
            player.SwitchNearPlayer = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && player.SwitchNearPlayer == this)
        {
            player.SwitchNearPlayer = null;
        }
    }

}
