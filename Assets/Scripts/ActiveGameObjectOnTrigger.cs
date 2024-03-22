using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameObjectOnTrigger : MonoBehaviour
{
    [SerializeField] private float _activationDuration;
    [SerializeField] private bool _activateTimerOnTriggerExit;

    [SerializeField] private List<GameObject> _activateObjects;

    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in _activateObjects)
        {
            obj.SetActive(true);
        }

        if(_activateTimerOnTriggerExit == false)
        {
            if(_coroutine == null) {
               _coroutine= StartCoroutine(DeactivateObjects(_activationDuration));
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_activateTimerOnTriggerExit) {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(DeactivateObjects(_activationDuration));
            }
        }
    }


    IEnumerator DeactivateObjects(float time)
    {
        yield return new WaitForSeconds(time);

        foreach(GameObject obj in _activateObjects)
        {
            obj.SetActive(false);
        }
        _coroutine = null;
    }
}

