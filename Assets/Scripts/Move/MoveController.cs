using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;

    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void InitializeMaxSpeed(float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
        speed = maxSpeed;
    }

    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        speed = maxSpeed;
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
