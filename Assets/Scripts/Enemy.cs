using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionFX;
    [SerializeField] private int points = 50;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Instantiate(explosionFX, transform.position, Quaternion.identity);
            gameManager.IncreaseScore(points);
            Destroy(gameObject);
        }
    }
}
