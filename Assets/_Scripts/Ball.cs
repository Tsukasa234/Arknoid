using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField] private float speed = 300;
    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;

        

        _rb.AddForce(velocity.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Deadzone")
        {
            Destroy(gameObject);
        }
    }
}
