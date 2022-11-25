using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float Cooldown;

    private bool _isReloading;
    private float _timer;

    private bool _isAttacking;

    public bool IsAttacking { get => _isAttacking; }

    void Update()
    {
        if (_isReloading)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _isReloading = false;
            }
        }

        if(Input.GetButtonDown("Fire1") && !_isReloading && !_isAttacking)
        {
            _isAttacking = true;
        }
    }

    public void Reload()
    {
        _isAttacking = false;
        _isReloading = true;
        _timer = Cooldown;
    }
}
