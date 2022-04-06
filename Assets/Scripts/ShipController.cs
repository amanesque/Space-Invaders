using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Bullet Properties")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;

    [Header("Player Ship Speed")]
    [SerializeField] private float speed = 5.0f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        // Check for key presses to move the spaceship
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // Check for Space key press to shoot bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject.Instantiate(bullet, muzzle.position, Quaternion.identity);
    }
}
