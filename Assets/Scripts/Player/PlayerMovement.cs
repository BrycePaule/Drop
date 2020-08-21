using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _moveAxis;
    

    private Rigidbody _rb;
    private InputManager _inputManager;

    private void Awake()
    {
        _rb = transform.GetComponentInParent<Rigidbody>();       
        _inputManager = InputManager.Instance;
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
        float timeDelta = Time.deltaTime;

        _rb.AddForce(new Vector3(_moveAxis.x * _moveSpeed, 0, _moveAxis.y * _moveSpeed));

    }
}
