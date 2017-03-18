using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public float walkSpeed = 1.5f;
	public float jumpSpeed;
	public float distToGround;
	public float hitPoint;

	float smoothTime = 1f;
	float axisValue;
	float attackRange = 0.4f;
	bool isJumping;
	bool isFacingRight = true;

	Rigidbody2D rigidBody;
	BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();

		boxCollider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update() {

		if (isJumping && isGrounded ()) {
			Jump ();
		}

		if (!isGrounded ()) {
			boxCollider.size = new Vector2 (boxCollider.size.x, 0.62f);
		} else {
			boxCollider.size =new Vector2(boxCollider.size.x, 0.72f);
		}

		//update where the player is facing
		if (axisValue < 0)
			isFacingRight = false;
		else if (axisValue > 0)
			isFacingRight = true;
			
		
	}
	void FixedUpdate () {
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, 0));

		//checking if the player is on the edge of the map
		//if yes setting the player back
		if (transform.position.x >= 19.175f)
			transform.position = Vector3.Lerp (transform.position,new Vector3 (19.1749f, transform.position.y,transform.position.z),smoothTime); 
		else if (transform.position.x <= -19)
			transform.position = Vector3.Lerp (transform.position,new Vector3 (-18.999f, transform.position.y,transform.position.z),smoothTime); 
		else
			transform.position += new Vector3 (axisValue * walkSpeed * Time.deltaTime ,0,0);
	}

	void Jump() {
		rigidBody.AddForce (Vector2.up * jumpSpeed);
	}

	public bool isGrounded() {

		return Physics2D.Raycast (transform.position, Vector2.down,distToGround);
	}

	public void SetAxisValue(float value) {
		axisValue = value;
	}

	public float GetAxisValue() {
		return axisValue;
	}

	public void SetJump(bool value) {
		isJumping = value;
	}

	public void Attack() {
		RaycastHit2D[] hits;
		//first get the hit
		if (isFacingRight)
			hits = Physics2D.RaycastAll (new Vector2(transform.position.x,transform.position.y + 0.5f), Vector2.right,attackRange);
		else
			hits = Physics2D.RaycastAll (new Vector2(transform.position.x,transform.position.y + 0.5f), Vector2.left,attackRange);

		//this is what the player hit, CAN be null
		GameObject enemy;
		foreach (RaycastHit2D hit in hits) {
			if (hit.collider != null) {
				enemy = hit.collider.gameObject;
				//NO friendly fire
				if (enemy.tag != this.tag) {
					//here is happening the code for attack
					Health enemyHealth = enemy.GetComponent<Health> ();
					enemyHealth.health -= hitPoint;
				}
			}
		}
	}
}
