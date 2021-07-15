using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCircleMover : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private void Start()
    {
        ChangeTargetPosition();
    }

    private void Update()
    {
        if (transform.position == _targetPosition)
            ChangeTargetPosition();

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private void ChangeTargetPosition()
    {
        _targetPosition = Random.insideUnitCircle * _radius;
    }
}
