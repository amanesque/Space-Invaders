using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSwarm : MonoBehaviour
{
    [Header("Invaders")]
    [SerializeField] private GameObject[] invaderTypes;

    [Header("Invaders' swarm Properties")]
    [SerializeField] private int rowCount = 4;
    [SerializeField] private int columnCount = 8;
    [SerializeField] private float xPadding = 0.8f;
    [SerializeField] private float yPadding = 0.8f;
    [SerializeField] private Transform spawnStartPos;

    [Header("Invaders' swarm Movement Properties")]
    [SerializeField] private float speedFactor = 3.0f;

    private GameObject[] invaders;
    private int invadersCount = 0;

    private float xMoveFactor;
    private bool isMovingRight = true;

    private float minX;
    private float maxX;
    private float currentX;

    private void Awake()
    {
        invaders = new GameObject[rowCount * columnCount];

        SpawnInvaders();
    }

    private void Update()
    {
        xMoveFactor = speedFactor * Time.deltaTime;

        if (isMovingRight)
        {
            currentX += xMoveFactor;
            if (currentX <= maxX)
            {
                MoveInvaders(xMoveFactor, 0);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            currentX -= xMoveFactor;
            if (currentX >= minX)
            {
                MoveInvaders(-xMoveFactor, 0);
            }
            else
            {
                ChangeDirection();
            }
        }
    }

    private void SpawnInvaders()
    {
        minX = spawnStartPos.position.x;
        maxX = minX + columnCount * (1.6f * xPadding);
        currentX = minX;

        Vector2 currentPos = spawnStartPos.position;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                invaders[invadersCount] = GameObject.Instantiate(invaderTypes[i], currentPos, Quaternion.identity);

                invaders[invadersCount++].transform.SetParent(transform);
                currentPos.x += xPadding;
            }

            currentPos.x = minX;
            currentPos.y -= yPadding;
        }
    }

    private void MoveInvaders(float x, float y)
    {
        foreach (GameObject invader in invaders)
        {
            if (invader != null)
            {
                invader.transform.Translate(x, y, 0);
            }
        }
    }

    private void ChangeDirection()
    {
        isMovingRight = !isMovingRight;
        MoveInvaders(0, -yPadding);
    }
}
