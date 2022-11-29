using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float BulletSpeed;
    public float ReloadTime;

    private bool _isShooting;
    private bool _isReloading;
    private float _timer;

    public bool IsShooting { get => _isShooting; set => _isShooting = value; }

    void Start()
    {
        
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
            Debug.Log("Atirou!");

            _isShooting = true;
            _isReloading = true;
            _timer = ReloadTime;
        }
    }
}
