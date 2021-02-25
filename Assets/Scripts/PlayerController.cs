using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public GameObject splash;
    public float contactPowerFactor;
    public Vector3 v { get; private set; }
    public UnityEvent<float, Color> onCollide;

    private Vector3 x0, x1;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        x0 = transform.position;
        _rb.gravityScale = 1;
    }

    void FixedUpdate()
    {
        x1 = transform.position;
        v = (x1 - x0) / Time.deltaTime;
        x0 = x1;

        float lr = -Input.GetAxis("Horizontal");
        //angle -= lr * Time.deltaTime * speed;
        //Physics2D.gravity = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)) * Physics2D.gravity.magnitude;
        _rb.angularVelocity = speed * lr * 1000f * Time.fixedDeltaTime;
        _rb.velocity += (Vector2)(Quaternion.Euler(0, 0, -90) * Physics2D.gravity.normalized) * speed * lr *.05f * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float power = 0;
        Color color = new Color();
        foreach (ContactPoint2D contact in collision.contacts)
        {
            power += contact.normalImpulse * contactPowerFactor;
            SpriteRenderer sprite = contact.collider.GetComponent<SpriteRenderer>();
            if (sprite)
                color += sprite.color / collision.contactCount;
            else
            {
                SpriteShapeRenderer shape = contact.collider.GetComponent<SpriteShapeRenderer>();
                if (shape)
                    color += shape.color / collision.contactCount;
            }

        }

        if (power > .1f)
        {
            onCollide?.Invoke(power, color);
            Instantiate(splash, collision.GetContact(0).point, new Quaternion());
        }
    }
}
