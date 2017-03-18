using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject roman;

	private int noOfEnemyOnMap = 3;

	// Use this for initialization
	void Start () {
		MakeNewRoman ();
		MakeNewRoman ();

	}
	
	// Update is called once per frame
	void Update () {
		if (NoOfEnemies () < noOfEnemyOnMap)
			MakeNewRoman ();
	}

	void MakeNewRoman() {
		float xPos = Random.Range (-15, 15);

		GameObject.Instantiate (roman,new Vector3(xPos,-0.5f),Quaternion.identity);
	}

	int NoOfEnemies() {
		return GameObject.FindGameObjectsWithTag ("Enemy").GetLength (0);
	}
		
}
