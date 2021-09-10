using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float speed;
    protected Rigidbody2D myBody;
    protected Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveDamage(int dam) {
        currentHealth -= dam;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Death();
        }
    }

    public void GainHealth(int gain) {
        currentHealth += gain;
        if (currentHealth >= maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public virtual void Death() {
        Destroy(gameObject);
    }

}
