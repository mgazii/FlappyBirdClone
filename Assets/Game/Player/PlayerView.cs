using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : AbstractView<PlayerController>
{
    void Start()
    {
        Controller.Init();
    }

    public void Rotate(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }

    public void Jump(Vector2 jump)
    {
        transform.GetComponent<Rigidbody2D>().velocity = jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Controller.OnCollision(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.OnTrigger(collision);
    }

    private void OnDestroy()
    {
        Controller.Destroy();
    }
}
