using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    public SlimeStates SlimeStates;
    public SlimeAIParameters AIParameters;
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
        player = GameManager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        IA();
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
        //Estado em Idle
        if (distance > AIParameters.ChaseDistance)
        {
            PlayAnimation("Idle");
            SlimeStates = SlimeStates.Idle;
        }
        //Estado de perseguir o player
        else if (distance > AIParameters.AtkRangedDistance)
        {
            SlimeStates = SlimeStates.Walk;
            PlayAnimation("Walk");
            Vector2 newPos = Vector2.MoveTowards(rigidbody2D.transform.position,
                                                    player.transform.position,
                                                    speed * Time.deltaTime);
            rigidbody2D.transform.position = newPos;
        }
        //Estado de atacar de longe
        else if (distance > AIParameters.AtkMeleeDistance)
        {
            if (AIParameters.doCooldownAtkRanged == true)
            {
                PlayAnimation("Idle");
            }
            else {
                PlayAnimation("AtkRanged");
                SlimeStates = SlimeStates.AtkRanged;
            }
        }
        //Estado de atacar em curta distância
        else if (distance <= AIParameters.AtkMeleeDistance) {
            PlayAnimation("AtkMelee");
            SlimeStates = SlimeStates.AtkMelee;
        }
    }

    public void CooldownAtkRanged() {
        StartCoroutine("DoCooldownRangedAttack");
    }

    private IEnumerator DoCooldownRangedAttack() {
        AIParameters.doCooldownAtkRanged = true;
        yield return new WaitForSeconds(AIParameters.cooldownAtkRanged);
        AIParameters.doCooldownAtkRanged = false;
    }

}
