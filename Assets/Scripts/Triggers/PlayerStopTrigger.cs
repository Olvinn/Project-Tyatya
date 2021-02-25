using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
            return;
        rb.velocity = rb.velocity * .05f;
        rb.angularVelocity = rb.angularVelocity * .05f;
    }
}
