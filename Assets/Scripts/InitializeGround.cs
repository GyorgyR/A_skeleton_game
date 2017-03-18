using UnityEngine;
using System.Collections;

public class InitializeGround : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
		float x = -19.5f;
		float y = -1.9f;
		float z = 0;

		for (int index = 1; index <= 130; index++) {
			Instantiate (prefab,new Vector3(x + index * 0.3f,y,z), Quaternion.identity);
		}
	
	}
}
