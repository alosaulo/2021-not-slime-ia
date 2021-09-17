using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector2 normal = new Vector2(hAxis, vAxis) * speed;

        Vector2 normalized = new Vector2(hAxis, vAxis).normalized * speed;

        myBody.velocity = normalized;

    }

    public override void Death()
    {
        GameManager.instance.AtivarTelaGameOver();
        base.Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyAtk") {
            RecieveDamage(1);
        }
    }

}
