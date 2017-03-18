using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
		health = 100;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//Death things happen
			Debug.Log("Wasted!");
			Destroy (gameObject);
		}
	
	}
}
