using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Bullet Properties")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;

    [Header("Player Ship Properties")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int lives = 3;

    [SerializeField] private GameObject explosionFX;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            gameManager.UpdateLife(lives);

            if (lives == 0)
            {
                gameManager.UpdateLife(lives);
                Destroy(gameObject);
            }

            GameObject.Instantiate(explosionFX, new Vector2(transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
        }
    }
}
