using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Controlls.IPlayerMovementActions
{


    private Controlls _controller;

    private Vector3 _moveDirection;

    [SerializeField] private float _moveSpeed;

    private Rigidbody _body;

   [SerializeField] private InteractSwitch _switchNearPlayer;

    public InteractSwitch SwitchNearPlayer { get => _switchNearPlayer; set => _switchNearPlayer = value; }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        Vector2 dir = context.ReadValue<Vector2>();

        _moveDirection = new Vector3( dir.x,0,dir.y);

    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            enabled = !enabled;


           if(enabled)
            {

                transform.position = GlobalVariables.ActivePlayer.transform.position;
                GlobalVariables.ActivePlayer = this;
            }
           if(enabled == false)
            {
                _body.velocity = Vector3.zero;
            }
        }
    }


    public void OnInteractWithSwitch(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _switchNearPlayer?.InteractWithSwitch();
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        if(_controller == null)
        {
            _controller = new Controlls();
            _controller.Enable();
            _controller.PlayerMovement.SetCallbacks(this);
        }

        _body = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        GlobalVariables.ActivePlayer = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _fallspeed = _body.velocity;
        _fallspeed = new Vector3(0, _fallspeed.y, 0);
        _body.velocity = _moveDirection * _moveSpeed + _fallspeed;
        //transform.position = transform.position + _moveSpeed * _moveDirection * Time.deltaTime;

    }

}
