using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Vector2 _moveAxis;
    

    private Rigidbody _rb;
    private InputManager _inputManager;
    private GameEventManager _gameEventManager;

    private void Awake()
    {
        _rb = transform.GetComponentInParent<Rigidbody>();       
        _inputManager = InputManager.Instance;
        _gameEventManager = GameEventManager.Instance;
    }

    private void OnEnable()
    {
        _gameEventManager.onJumpPress += OnJumpPress;
    }

    private void OnDisable()
    {
        _gameEventManager.onJumpPress -= OnJumpPress;
    }

    private void Update()
    {
        _moveAxis = _inputManager.PlayerMoveAxis;
    }

    private void FixedUpdate()
    {
        if (_moveAxis != Vector2.zero)
        {
            Move();
        }
    }

    private void Move()
    {   
        _rb.AddForce(new Vector3(_moveAxis.x * _moveSpeed, 0, _moveAxis.y * _moveSpeed));
    }

    private void OnJumpPress()
    {
        print("jumping");
        _rb.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
