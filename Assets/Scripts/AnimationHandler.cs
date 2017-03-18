using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {

	float axisValue;

	Animator[] animators;
	SpriteRenderer[] spriteRender;
	PlayerMover playerMove;

	// Use this for initialization
	void Start () {
		animators = GetComponentsInChildren <Animator> ();

		spriteRender = GetComponentsInChildren<SpriteRenderer> ();

		playerMove = GetComponent<PlayerMover> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (axisValue < 0) {
			spriteRender [0].enabled = false;
			spriteRender [1].enabled = true;
		} else if (axisValue == 0) {
			;
		} else {
			spriteRender [0].enabled = true;
			spriteRender [1].enabled = false;
		}
	
		//handling animations
		//if axis value is not 0 the player is walking so we set the animation
		if (axisValue != 0 && playerMove.isGrounded ()) {
			foreach(Animator animator in animators)  
				animator.SetBool ("isWalking", true);
		} else {
			foreach(Animator animator in animators)  
				animator.SetBool ("isWalking", false);
		}

		if (!playerMove.isGrounded ()) {
			foreach (Animator animator in animators) {
				animator.SetBool ("Jump", true);
				animator.SetBool ("AirBorne",true);
			}
		} else {
			foreach (Animator animator in animators) {
				animator.SetBool ("Jump", false);
				animator.SetBool ("AirBorne",false);
			}
		}
	}

	public void Attack() {
		foreach (Animator animator in animators) {
			animator.SetTrigger ("Attack");
		}
	}

	public void SetAxisValue(float value) {
		axisValue = value;
	}
}
