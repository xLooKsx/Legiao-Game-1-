using UnityEngine;
using System.Collections;

public enum AnimationStates
{
	IDLE,
	WALK,
	JUMP,
	ATTACK

}
public class AnimationController : MonoBehaviour 
{
	public Animator Animator;

	public void PlayAnimation(AnimationStates stateAnimation)
	{
		switch (stateAnimation) 
		{
		case AnimationStates.IDLE:
		{
			StopAnimations ();
			Animator.SetBool("inIdle", true);
		}
		break;
		case AnimationStates.WALK:
		{
			StopAnimations ();
			Animator.SetBool("inWalk", true);
		}
		break;
		case AnimationStates.JUMP:
		{
			StopAnimations ();
			Animator.SetBool("inJump", true);
		}
		break;
		case AnimationStates.ATTACK:
		{
			StopAnimations ();
			Animator.SetBool("attacking", true);
		}
			break;

		}
	}


	public void StopAnimations()
	{
		Animator.SetBool("inIdle", false);
		Animator.SetBool("inWalk", false);
		Animator.SetBool("inJump", false);
		Animator.SetBool("attacking", false);
	}
}
