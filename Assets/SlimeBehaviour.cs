using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public SlimeAIParameters AIParameters;
    public SlimeStates SlimeStates;
    public float speed;

    Animator animator;
    Rigidbody2D rigidbody2D;

    string animationState;
    
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameManager._gm.Player;
    }

    // Update is called once per frame
    void Update()
    {
        IA();
        switch (SlimeStates)
        {
            case SlimeStates.Idle:
                break;
            case SlimeStates.Walk:
                
                break;
            case SlimeStates.AtkMelee:
                
                break;
            case SlimeStates.AtkRanged:
               
                break;
            case SlimeStates.Damage:
                
                break;
            case SlimeStates.Death:
               
                break;
            default:
                break;
        }

        PlayAnimation(SlimeStates.ToString());
    }

    void PlayAnimation(string animationToPlay) {
        if (animationState == animationToPlay)
            return;
        animationState = animationToPlay;
        animator.Play(animationState);
    }

    public void IA() {
        float distance = Vector2.Distance(player.transform.position, 
            transform.position);
        Debug.Log(distance);
        if (distance > AIParameters.ChaseDistance)
        {
            SlimeStates = SlimeStates.Idle;
        }
        else if (distance > AIParameters.AtkRangedDistance)
        {
            SlimeStates = SlimeStates.Walk;
            Vector2 newPos = Vector2.MoveTowards(rigidbody2D.transform.position,
                                                    player.transform.position,
                                                    speed * Time.fixedDeltaTime);
            rigidbody2D.transform.position = newPos;
        }
        else if (distance > AIParameters.AtkMeleeDistance)
        {
            SlimeStates = SlimeStates.AtkRanged;
        }
        else if (distance <= AIParameters.AtkMeleeDistance) {
            SlimeStates = SlimeStates.AtkMelee;
        }
    }

}
