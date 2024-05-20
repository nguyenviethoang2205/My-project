using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Food : MonoBehaviour
{
    [SerializeField] private float speed = 0f;

    void Start()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        // Collider2D bottomCollider = bottom.GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Destroy(gameObject);
    }
}
