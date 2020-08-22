using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionResetter : MonoBehaviour
{

    [SerializeField] private Vector3 _startPoint;

    private GameEventManager _gameEventManager;

    private void Awake()
    {
        _gameEventManager = GameEventManager.Instance;
    }


    void OnCollisionEnter(Collision other)
    {
        _gameEventManager.OnPlayerReset();
        other.transform.position = _startPoint;
    }
}
