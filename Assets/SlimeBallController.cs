using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBallController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidBody;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Vector3 playerPos = GameManager.instance.Player.transform.position;
        target = playerPos - transform.position;
        rigidBody.velocity = target.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            PlayerController player = 
                collision.gameObject.GetComponent<PlayerController>();
            player.RecieveDamage(1);
        }
        Destroy(gameObject);
    }

}
