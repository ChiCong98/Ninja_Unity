using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBehavious : StateMachineBehaviour
{
    private Vector2 slideSize = new Vector2(1.45f, 2.1f);
    private Vector2 slideOffset = new Vector2(0,- 1.15f);

    private Vector2 size;
    private Vector2 offset;

    private BoxCollider2D boxCollider;

    public float increatSpeed;

    float speedCharacter;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Instance.Slide = true;
        speedCharacter = Player.Instance.GetMoveSpeed();
        if (boxCollider==null)
        {
            boxCollider = Player.Instance.GetComponent<BoxCollider2D>();
            size = boxCollider.size;
            offset = boxCollider.offset;
        }
        boxCollider.size = slideSize;
        boxCollider.offset = slideOffset;
        if(Player.Instance.GetIsGround())
            Player.Instance.SetMoveSpeed(speedCharacter + increatSpeed);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Instance.Slide = false;
        animator.ResetTrigger("slide");
        boxCollider.size = size;
        boxCollider.offset = offset;
        Player.Instance.SetMoveSpeed(speedCharacter);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
