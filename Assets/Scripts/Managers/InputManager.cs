﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public Vector2 PlayerMoveAxis;

    private PlayerInputActions _input;
    private GameEventManager _gameEventManager;

    #region Singleton
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InputManager>();
                if (_instance == null)
                {
                    _instance = new InputManager();
                }
            }
            return _instance;
        }
    }
    #endregion Singleton

    private void Awake()
    {
        _input = new PlayerInputActions();
        _gameEventManager = GameEventManager.Instance;

        _input.Movement.Move.performed += ctx => OnPlayerMove(ctx.ReadValue<Vector2>());
        _input.Movement.Move.canceled += ctx => OnPlayerStopMove();
        _input.Movement.Jump.performed += ctx => OnPlayerJump();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnPlayerMove(Vector2 context)
    {
        PlayerMoveAxis = context;
    }

    private void OnPlayerStopMove()
    {
        PlayerMoveAxis = Vector2.zero;
    }

    private void OnPlayerJump()
    {
        _gameEventManager.OnJumpPress();
    }
}
