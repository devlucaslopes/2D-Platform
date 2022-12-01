using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private GameObject BulletPrefab;

    [SerializeField] private float BulletSpeed;
    [SerializeField] private float ReloadTime;

    private PlayerMovement movement;

    private bool _isShooting;
    private bool _isReloading;
    private float _timer;

    public bool IsShooting { get => _isShooting; set => _isShooting = value; }

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (_isReloading)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _isReloading = false;
                _timer = 0;
            }
        }

        if (Input.GetButtonDown("Fire1") && !_isReloading)
        {
            _isShooting = true;
            _isReloading = true;
            _timer = ReloadTime;

            Bullet bullet = Instantiate(BulletPrefab, ShootPoint.position, ShootPoint.rotation).GetComponent<Bullet>();

            bullet.Speed = BulletSpeed;
            bullet.Direction = movement.LookToRight ? 1 : -1;
        }
    }
}
