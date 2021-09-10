using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : Character
{
    public SlimeStates SlimeStates;
    public SlimeAIParameters AIParameters;

    public GameObject ProjectilePrefab;
    public Transform ProjectileOrigin;

    string animationState;
    
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
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
            Vector2 newPos = Vector2.MoveTowards(myBody.transform.position,
                                                    player.transform.position,
                                                    speed * Time.deltaTime);
            myBody.transform.position = newPos;
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
            if (AIParameters.doCooldownAtkMelee == true)
            {
                PlayAnimation("Idle");
            }
            else {
                PlayAnimation("AtkMelee");
                SlimeStates = SlimeStates.AtkMelee;
            }
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

    public void CooldownAtkMelee() {
        StartCoroutine("DoCooldownAtkMelee");
    }

    private IEnumerator DoCooldownAtkMelee() {
        AIParameters.doCooldownAtkMelee = true;
        yield return new WaitForSeconds(AIParameters.cooldownAtkMelee);
        AIParameters.doCooldownAtkMelee = false;
    }

    public void ShootProjectile() {
        Instantiate(ProjectilePrefab,
            ProjectileOrigin.position,
            Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            this.RecieveDamage(1);
        }
    }

}
