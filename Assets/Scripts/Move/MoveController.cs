using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D rb;


    [SerializeField]
    private float speed;

    private Vector2 direction = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + direction.normalized * speed * Time.fixedDeltaTime);

    }
}
