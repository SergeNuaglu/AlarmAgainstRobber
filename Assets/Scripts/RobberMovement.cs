using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class RobberMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _atDoorPoint;
    [SerializeField] private UnityEvent _reachedDoor;

    private NavMeshAgent _agent;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        _agent.SetDestination(_points[_currentPoint].position);

        if (transform.position.x == _points[_currentPoint].position.x && transform.position.z == _points[_currentPoint].position.z)
        {
            if (_points[_currentPoint].position == _atDoorPoint.position)
            {
                _reachedDoor?.Invoke();
            }

            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                Destroy(this);
            }
        }
    }
}
