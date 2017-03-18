using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	PlayerMover mover;
	GameObject player;
	Animator anim;
	SpriteRenderer renderer;
	float targetX = 0;
	float axisValue = 0;
	float range = 2.5f;
	float attackCooldown = 0;
	bool reachedDest;


	// Use this for initialization
	void Start () {

		//grab the PlayerMover script
		mover = GetComponent<PlayerMover> ();

		//grab animator
		anim = GetComponent<Animator> ();

		//grab renderer
		renderer = GetComponent<SpriteRenderer> ();

		//get the player
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerInRange())
			FightPlayer ();
		else
			PeaceFul ();

		//flip the sprite according to the axisValue
		if (axisValue < 0)
			renderer.flipX = true;
		else if(axisValue > 0)
			renderer.flipX = false;

		//set the axis value
		mover.SetAxisValue (axisValue);
		anim.SetInteger ("axisValue",(int) axisValue);

		reachedDest = MoveToTarget ();

		if(attackCooldown >= 0)
			attackCooldown -= Time.deltaTime;
	
	}

	bool isPlayerInRange() {
		if (player != null)
			return DistToPoint (player.transform.position.x) < range;
		else {
			FindPlayer ();
			return false;
		}
			
	}

	float DistToPoint(float otherX) {
		if (player != null)
			return Mathf.Abs (otherX - transform.position.x);
		else {
			FindPlayer ();
			return 0;
		}
	}

	void FindPlayer() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void PeaceFul() {
		//if close to the target point get a new point
		if (reachedDest)
			targetX = Random.Range (-15, 15);
	}

	bool MoveToTarget() {
		//determine if axis value should be 1 or -1
		//adding to the values so the enemy would not run in the  player
		if (targetX > transform.position.x + 0.5) {
			axisValue = 1;
			return false;
		} else if (targetX < transform.position.x - 0.3) {
			axisValue = -1;
			return false;
		} else {
			axisValue = 0;
			return true;
		}
	}

	void FightPlayer() {
		targetX = player.transform.position.x;

		if (reachedDest && attackCooldown <= 0) {
			Debug.Log ("Attack");
			anim.SetTrigger ("attack");
			mover.Attack ();
			attackCooldown = 3;
		}
	}

}
