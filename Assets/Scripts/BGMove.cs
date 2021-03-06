using UnityEngine;
using System.Collections;

public class BGMove : MonoBehaviour {


	public float rollSpeed;
	public float smooth;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentVel = Vector3.zero;

		if(player != null && player.transform.position.x < 15.64f && player.transform.position.x > -15.64f)
			transform.position = Vector3.SmoothDamp (transform.position,new Vector3(player.transform.position.x*rollSpeed,transform.position.y,transform.position.z), ref currentVel, smooth);
	}
}
