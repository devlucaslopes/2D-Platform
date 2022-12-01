using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform Platform;
    [SerializeField] private Transform[] Waypoints;

    [SerializeField] private float Speed;

    private int _indexWaypoint = 0;

    void Start()
    {
        Platform.position = Waypoints[0].position;
    }

    void Update()
    {
        Platform.position = Vector3.MoveTowards(Platform.position, Waypoints[_indexWaypoint].position, Speed * Time.deltaTime);

        float distance = Vector3.Distance(Platform.position, Waypoints[_indexWaypoint].position);

        if (distance <= 0)
        {
            _indexWaypoint++;

            if (_indexWaypoint >= Waypoints.Length)
            {
                _indexWaypoint = 0;
            }
        }
    }
}
