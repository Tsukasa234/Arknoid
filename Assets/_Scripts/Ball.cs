using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField] private float speed = 300;
    private Vector2 velocity = Vector2.zero;

    private Vector2 initialBallPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        initialBallPosition = transform.position;

       ResetBall();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Deadzone"))
        {
            GameManager.Instance.LostHealth();
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
