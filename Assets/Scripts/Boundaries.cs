using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float spriteHalfWidth;
    private float spriteHalfHeight;

    private void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        spriteHalfWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        spriteHalfHeight = GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;
    }

    private void LateUpdate()
    {
        // Clamping position of the gameObject to screen size
        Vector2 tempVec = transform.position;
        tempVec.x = Mathf.Clamp(tempVec.x, -screenBounds.x + spriteHalfWidth, screenBounds.x - spriteHalfWidth);
        tempVec.y = Mathf.Clamp(tempVec.y, -screenBounds.y + spriteHalfHeight, screenBounds.y - spriteHalfHeight);
        transform.position = tempVec;
    }
}
