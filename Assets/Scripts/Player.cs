using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float playerPositionLimit;
    
    float yInput;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void Update()
    {
        PlayerInputs();
        PlayerPositionRestriction();
    }

    void PlayerMove()
    {
        rb.velocity = new Vector3(0, yInput * moveSpeed, 0);
    }

    void PlayerInputs()
    {
        yInput = Input.GetAxisRaw("Vertical");
    }

    void PlayerPositionRestriction()
    {
        if (transform.position.y >= playerPositionLimit)
            transform.position = new Vector3(transform.position.x, (-playerPositionLimit + 0.1f));

        if (transform.position.y <= -playerPositionLimit)
            transform.position = new Vector3(transform.position.x, (playerPositionLimit - 0.1f));
    }
}
