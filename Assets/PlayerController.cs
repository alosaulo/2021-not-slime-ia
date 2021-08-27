using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    public float speed;
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector2 normal = new Vector2(hAxis, vAxis) * speed;

        Vector2 normalized = new Vector2(hAxis, vAxis).normalized * speed;

        rigidBody.velocity = normalized;

    }
}
