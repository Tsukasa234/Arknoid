using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
        }
    }
}
