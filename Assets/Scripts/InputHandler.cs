using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	float horizontalAxis;

	PlayerMover playerMove;
	AnimationHandler animHandler;

	// Use this for initialization
	void Start () {

		playerMove = GetComponent<PlayerMover> ();

		animHandler = GetComponent<AnimationHandler> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		horizontalAxis = Input.GetAxis ("Horizontal");

		if(Input.GetButtonDown ("Fire1")) {
			animHandler.Attack ();
			playerMove.Attack ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			playerMove.SetJump (true);
		} else {
			playerMove.SetJump (false);
		}

		playerMove.SetAxisValue (horizontalAxis);
		animHandler.SetAxisValue (horizontalAxis);
	}
}
