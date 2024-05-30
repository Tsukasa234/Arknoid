using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float inputValue = 0;

    private Vector2 direction;

    [SerializeField] private float moveSpeed = 25;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue <= -0.3)
        {
            direction = Vector2.left;
        }
        else if (inputValue >= 0.3)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }

        _rb.AddForce(direction * moveSpeed * Time.deltaTime * 100);
    }
}
