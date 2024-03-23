using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRiddle : Riddle
{

    [SerializeField] private List<FloorPlates> _floorPlates;
    private int _counter;

  [SerializeField]  private GameObject _door;

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
            _door.SetActive(false);
        }
        
    }

    public override void ResetRiddle()
    {
        _counter = 0;

        foreach(FloorPlates floorPlate in _floorPlates)
        {
            floorPlate.Reset();
        }
    }

}
