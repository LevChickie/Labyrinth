using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour {

	public GameObject wallHorizontal;
	public GameObject wallVertical;
	public GameObject scores;
	public GameObject player;

	public int labirinthWidth;
	public int labirinthHeight;
	bool verticalActive;
	Vector3 position;
	List<AssemblyCSharp.WallCoordinates> wallCoordinates;
	// Use this for initialization
	float chance;
	void Start () {
		wallCoordinates = new List<AssemblyCSharp.WallCoordinates> ();
		for (int i = -49; i <= 50; i++) {
			for (int j = -49; j <= 50; j++) {
				verticalActive = false;
				chance = Random.Range (0f, 100f);
				if (chance > 40f) {
					position = new Vector3 (i * 10-5, 0, j * 10);
					Instantiate (wallHorizontal, position, Quaternion.identity);
					verticalActive = true;
					wallCoordinates.Add(new AssemblyCSharp.WallCoordinates(i,j,"horizontal",true));
				}
				else{
					wallCoordinates.Add (new AssemblyCSharp.WallCoordinates (i, j,"horizontal" , false));			
				}
				chance = Random.Range (0f, 100f);
				if (verticalActive) {
					if (chance > 60f) {
						Quaternion spawnRotation = Quaternion.Euler (0, 90, 0);
						position = new Vector3 (i * 10 - 5, 0f, j * 10 - 5);
						Instantiate (wallVertical, position, spawnRotation);
						wallCoordinates.Add(new AssemblyCSharp.WallCoordinates(i,j,"vertical",true));
					}
				}
				else {
					if (chance > 40f) {
						Quaternion spawnRotation = Quaternion.Euler (0, 90, 0);
						position = new Vector3 (i * 10 - 5, 0f, j * 10 - 5);
						Instantiate (wallVertical, position, spawnRotation);
						wallCoordinates.Add (new AssemblyCSharp.WallCoordinates (i, j, "vertical", true));

					} else {
						wallCoordinates.Add(new AssemblyCSharp.WallCoordinates(i,j,"vertical",false));

					}
				} 
			}
		
				float x = Random.Range (-500f, 500f);
				float y = Random.Range (-500f, 500f);
				position = new Vector3 (x, 0.5f, y);
				Instantiate (scores, position, Quaternion.identity);
		
		}
	}
	
	// Update is called once per frame
	void Update () {
	//	player.transform.rotation.Set (0.0f, 0.0f, 0.0f, 0.0f);

	}
}
