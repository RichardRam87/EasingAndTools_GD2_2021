using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tween
{
    private GameObject _gameObject;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _direction;

    private float _speed;
    private float _percent;

    private Func<float, float> EaseMethod;
    
    public Tween(GameObject objectToMove, Vector3 targetPosition, float speed, Func<float, float> Method)
    {
        _gameObject = objectToMove;
        _targetPosition = targetPosition;
        _speed = speed;

        _startPosition = _gameObject.transform.position;
        _direction = _targetPosition - _startPosition;
        _percent = 0;

        // TODO: In argument verwerken van constructor
        EaseMethod = Method;
        
        Debug.Log("Tween Started");
    }

    public void UpdateTween(float dt)
    {
        _percent += dt / _speed;

        if (_percent < 1)
        {
            float easeStep = EaseMethod(_percent);
            _gameObject.transform.position = _startPosition + (_direction * easeStep);
            Debug.Log(_gameObject + ": Tween Update");
        }
        else
        {
            //TODO: deze print wordt elke frame aangeroepen. Moet ik nog fixen... Huiswerk??
            _gameObject.transform.position = _targetPosition;
            Debug.Log("Tween Finished!");
        }
    }
}