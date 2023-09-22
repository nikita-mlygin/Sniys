using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ActorPlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private Vector2 direction = Vector2.zero;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + direction.normalized * speed * Time.fixedDeltaTime);
    }
}
