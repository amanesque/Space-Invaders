using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestoy : MonoBehaviour
{
    [SerializeField] private float lifetime = 3.0f;

    private void Awake()
    {
        Invoke("SelfDestroy", lifetime);
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
