using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject _respawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        GlobalVariables.ActivePlayer.transform.position = _respawnPoint.transform.position;
    }
}
