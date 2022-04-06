using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Enemy Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform muzzle;

    private int spawnInterval;
    private int counter;

    private void Awake()
    {
        spawnInterval = Random.Range(300, 500);
    }

    private void Update()
    {
        counter++;

        if (counter >= spawnInterval)
        {
            Shoot();
            counter = 0;
        }
    }

    private void Shoot()
    {
        GameObject.Instantiate(bullet, muzzle.position, Quaternion.identity);
    }
}
