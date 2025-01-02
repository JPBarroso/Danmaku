using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField] private float _shotCooldown;
    [SerializeField] private RadialShotSettings _shotSettings;
    private float _shotCooldownTimer = 0f;

    private void Update()
    {
        _shotCooldownTimer -= Time.deltaTime;

        if(_shotCooldownTimer <= 0f)
        {
            ShotAttack.RadialShot(transform.position, transform.up, _shotSettings);
            _shotCooldownTimer += _shotCooldown;
        }
    }
}
