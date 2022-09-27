using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float ySpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(0, ySpeed * 10);
    }
}
