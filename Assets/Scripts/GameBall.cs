using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float ballXDirection;
    [SerializeField] float ballYDirection;
    [SerializeField] float ballSpeed;

    bool canMove = false;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SetupRandomYDirection();

        Invoke(nameof(SetupBallCanMove), 2f);
    }

    void FixedUpdate()
    {
        if (canMove)
            BallMove();
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
        rb.velocity = new Vector2(ballSpeed * ballXDirection, ballSpeed * ballYDirection);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y < collision.transform.position.y && collision.transform.position.x == 0)
            ballYDirection *= -1;

        if (transform.position.y > collision.transform.position.y && collision.transform.position.x == 0)
            ballYDirection *= -1;

        if (collision.gameObject.GetComponent<Player>() != null)
            ballXDirection *= -1;

        //TODO: Add enemy (computer) collision

        //TODO: remove the following IF after testing
        if (transform.position.x < collision.transform.position.x && collision.transform.position.y == 0)
            ballXDirection *= -1;

        //TODO: remove the following IF after testing
        if (transform.position.x > collision.transform.position.x && collision.transform.position.y == 0)
            ballXDirection *= -1;
    }

    void SetupBallCanMove() => canMove = true;
}
