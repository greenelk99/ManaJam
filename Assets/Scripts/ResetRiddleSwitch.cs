using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRiddleSwitch : MonoBehaviour
{
    [SerializeField] private Riddle _riddle;


    private void OnTriggerEnter(Collider other)
    {
        _riddle.ResetRiddle();
    }
}
