using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    PlayerController target;

    private void Start()
    {
        moveSpeed = GetComponent<Enemy>().speed;
        rb2d = GetComponent<Rigidbody2D>();
        target = PlayerController.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
}
