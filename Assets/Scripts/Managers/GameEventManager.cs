﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameEventManager : MonoBehaviour
{
    private static GameEventManager _instance;

    private InputManager _inputManager;

    public static GameEventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameEventManager>();
                if (_instance == null)
                {
                    _instance = new GameEventManager();
                }
            }
            return _instance;
        }
    }

    private void Awake() 
    {
        // if (_instance != null) { Destroy(gameObject); }

        _inputManager = InputManager.Instance;
    }

    // EVENTS
    public event Action onJumpPress;
    public event Action onPlayerReset;

    public void OnJumpPress()
    {
        if (onJumpPress == null) { return; }
        onJumpPress();
    }

    public void OnPlayerReset()
    {
        if (onPlayerReset == null) { return; }
        onPlayerReset();
    }

}
