using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	private Rigidbody enemy;
	private int direction=1;
	private float chance;
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		chance = Random.Range (0, 100);
		if (chance < 50) {
			AttemptMove ();
		}                                                                                                                                                
	}
	void AttemptMove(){
		switch (direction) {
		case 1:
			enemy.MovePosition (new Vector3 (enemy.transform.position.x + 0.1f, enemy.transform.position.y, enemy.transform.position.z));
			ChangeDirection (1);
			break;
		case 2:
			enemy.MovePosition (new Vector3 (enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 0.1f));
			ChangeDirection (2);
			break;
		case 3:
			enemy.MovePosition (new Vector3 (enemy.transform.position.x - 0.1f, enemy.transform.position.y, enemy.transform.position.z));
			ChangeDirection (3);
			break;
		case 4:
			enemy.MovePosition (new Vector3 (enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - 0.1f));
			ChangeDirection (4);
			break;
		default:
			chance = Random.Range (1, 4);
			ChangeDirection ((int)chance);
			break;

		}

		direction = Random.Range (1, 4);  
	}
	void ChangeDirection(int directionNow){
		chance = Random.Range (0, 100);
		if (chance < 60) {
			chance = Random.Range (0, 100);
			if (chance < 25f)
				direction = 1;
			else if (chance < 50f)
				direction = 3;
			else if (chance < 75f)
				direction = 2;
			else if (chance < 100f){
				direction = 4;
			}
		}
	}

	void Move(int direction){
		
	}
}
