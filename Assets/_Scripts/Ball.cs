using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField] private float speed = 300;
    private Vector2 velocity = Vector2.zero;

    private Vector2 initialBallPosition;

    private AudioSource _as;

    [SerializeField] private AudioClip playerSound, brickSound, deathSound, wallSound;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _as = GetComponent<AudioSource>();
        
        initialBallPosition = transform.position;

       ResetBall();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Deadzone"))
        {
            GameManager.Instance.LostHealth();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            _as.clip = playerSound;
            _as.Play();
        }
        else if (other.gameObject.CompareTag("Brick"))
        {
            _as.clip = brickSound;
            _as.Play();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            _as.clip = wallSound;
            _as.Play();
        }
        else if (other.gameObject.CompareTag("Deadzone"))
        {
            _as.clip = deathSound;
            _as.Play();
        }
    }

    public void ResetBall()
    {
        transform.position = initialBallPosition;
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(velocity.normalized * speed);
    }
}
