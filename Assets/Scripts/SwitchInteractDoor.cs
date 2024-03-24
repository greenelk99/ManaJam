using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteractDoor : MonoBehaviour
{

    [SerializeField] private Switch _switch;

    [SerializeField] private float _doorOpenDurationInSeconds;
    [SerializeField] private Vector3 _MoveDoorByOnOpening;

    private void Awake()
    {
        _switch.SwitchActivation += OpenDoor;
    }


    private void OpenDoor(bool active)
    {
        //gameObject.SetActive(!active);

        StartCoroutine(OpenDoorAnimation(active));
    }

    private IEnumerator OpenDoorAnimation(bool open)
    {
        int stepAmount = (int)(_doorOpenDurationInSeconds / 0.1f);
        Vector3 stepValue =_MoveDoorByOnOpening/ stepAmount;

        if(open == false)
        {
            stepValue = stepValue * -1;
        }

        for(int i =0; i < stepAmount; i++)
        {
            transform.position = transform.position+ stepValue;
            yield return new WaitForSeconds(0.1f);
        }

       
    }
}
