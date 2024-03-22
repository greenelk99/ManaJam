using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Vector3 _cammeraOffsetToPlayer;

    // Update is called once per frame
    void Update()
    {

        

        transform.position = GlobalVariables.ActivePlayer.transform.position + _cammeraOffsetToPlayer;
    }
}
