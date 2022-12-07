using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private Transform[] Waypoints;

    private SpriteRenderer spriteRenderer;

    private int _indexWaypoint = 0;
    private Transform _currentWaypoint;
    private int _direction = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        _currentWaypoint = Waypoints[_indexWaypoint];
        transform.position = _currentWaypoint.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, MoveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, RotationSpeed * _direction * Time.deltaTime));

        if (Vector3.Distance(transform.position, _currentWaypoint.position) <= 0)
        {
            _indexWaypoint++;

            if (_indexWaypoint >= Waypoints.Length)
            {
                _indexWaypoint = 0;
            }

            _currentWaypoint = Waypoints[_indexWaypoint];

            if (transform.position.x > _currentWaypoint.position.x)
            {
                spriteRenderer.flipX = false;
                _direction = 1;
            } else
            {
                spriteRenderer.flipX = true;
                    _direction = -1;
            }
        }
    }
}
