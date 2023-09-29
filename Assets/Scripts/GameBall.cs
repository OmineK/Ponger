using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float ballSpeed;

    public float ballXDirection { get; private set; } = 1;
    public bool canMove = false;

    float ballYDirection = 1;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        newRoundStart();
    }

    void FixedUpdate()
    {
        BallMove();
    }

    public void newRoundStart()
    {
        Invoke(nameof(SetupBallCanMove), 2f);
        SetupRandomYDirection();
    }

    void SetupRandomYDirection()
    {
        int randomYStartDir = Random.Range(0, 2);

        if (randomYStartDir == 0)
            return;
        else if (randomYStartDir == 1)
            ballYDirection *= -1;
    }

    void BallMove()
    {
        if (canMove)
            rb.velocity = new Vector2(ballSpeed * ballXDirection, ballSpeed * ballYDirection);
        else
            rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y < collision.transform.position.y && collision.transform.position.x == 0)
            ballYDirection *= -1;

        if (transform.position.y > collision.transform.position.y && collision.transform.position.x == 0)
            ballYDirection *= -1;

        if (collision.gameObject.GetComponent<Player>() != null)
            ballXDirection *= -1;

        if (collision.gameObject.GetComponent<Enemy>() != null)
            ballXDirection *= -1;
    }

    void SetupBallCanMove() => canMove = true;
}
