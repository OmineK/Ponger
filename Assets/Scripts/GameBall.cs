using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float ballSpeed;

    public float ballXDirection { get; private set; } = 1;
    [NonSerialized] public bool canMove = false;

    float ballYDirection = 1;

    Rigidbody2D rb;
    AudioSource audioSource;
    ParticleSystem ballParticle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        ballParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        newRoundStart();
    }

    void FixedUpdate()
    {
        BallMove();
        PlayBallParticles();
    }

    public void newRoundStart()
    {
        Invoke(nameof(SetupBallCanMove), 2f);
        SetupRandomYDirection();
    }

    void BallMove()
    {
        if (canMove)
            rb.velocity = new Vector2(ballSpeed * ballXDirection, ballSpeed * ballYDirection);
        else
            rb.velocity = Vector3.zero;
    }

    void PlayBallParticles()
    {
        if (canMove)
            ballParticle.Play();
        else
        {
            ballParticle.Pause();
            ballParticle.Clear();
        }
    }

    void SetupBallCanMove() => canMove = true;

    void SetupRandomYDirection()
    {
        int randomYStartDir = UnityEngine.Random.Range(0, 2);

        if (randomYStartDir == 0)
            return;
        else if (randomYStartDir == 1)
            ballYDirection *= -1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y < collision.transform.position.y && collision.transform.position.x == 0)
        {
            ballYDirection *= -1;
            PlayRandomPitchSound();
        }

        if (transform.position.y > collision.transform.position.y && collision.transform.position.x == 0)
        {
            ballYDirection *= -1;
            PlayRandomPitchSound();
        }

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            ballXDirection *= -1;
            PlayRandomPitchSound();
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            ballXDirection *= -1;
            PlayRandomPitchSound();
        }
    }

    void PlayRandomPitchSound()
    {
        audioSource.Play();

        float randomPitch = UnityEngine.Random.Range(0.9f, 1.2f);
        audioSource.pitch = randomPitch;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        newRoundStart();
    }
}