using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ActorPlayer : MonoBehaviour
{
    private MoveController moveController;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        moveController.SetDirection(new Vector2()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical"),
        });
    }
}
