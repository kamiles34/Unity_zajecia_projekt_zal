using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : StateMachineBehaviour
{
    public float timer;
    public float speed;

    private int rand;

    private Transform playerPos;
    private Vector2 target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rand = Random.Range(0, 2);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            if (rand == 0)
            {
                animator.SetTrigger("Idle");

            }
            else
            {
                animator.SetTrigger("WalkAttack");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
        Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}