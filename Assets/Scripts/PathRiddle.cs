using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRiddle : Riddle
{

    [SerializeField] private List<FloorPlates> _floorPlates;
    private int _counter;

    [SerializeField]  private GameObject _door;
    [SerializeField] private float _doorOpenDurationInSeconds;
    [SerializeField] private Vector3 _moveDoorByOnOpening;

    private void Awake()
    {
        _counter = 0; 
        foreach(FloorPlates floorPlate in _floorPlates)
        {
            floorPlate.PlateActivation += HitFloorPlate;
        }
    }

    public void HitFloorPlate()
    {
        _counter= _counter + 1;
        DeactivatedDoor();
    }


    private void DeactivatedDoor()
    {
        if(_counter >= _floorPlates.Count)
        {
            //_door.SetActive(false);
            StartCoroutine(OpenDoorAnimation(true));
        }
        
    }


    public override void ResetRiddle()
    {
        _counter = 0;

        foreach(FloorPlates floorPlate in _floorPlates)
        {
            floorPlate.ResetFloorPlate();
        }
    }
    private IEnumerator OpenDoorAnimation(bool open)
    {
        int stepAmount = (int)(_doorOpenDurationInSeconds / 0.1f);
        Vector3 stepValue = _moveDoorByOnOpening / stepAmount;

        if (open == false)
        {
            stepValue = stepValue * -1;
        }

        for (int i = 0; i < stepAmount; i++)
        {
          _door.transform.position = _door.transform.position + stepValue;
            yield return new WaitForSeconds(0.1f);
        }


    }
}
