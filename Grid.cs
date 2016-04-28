using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject Tile;
	public GameObject Hole;
	public GameObject Goal;
	public GameObject Enemy;

	public Toggle obsToggle;
	public Toggle disToggle;

	public bool enemyActive;
	public static bool isDiscrete;
	public static bool isObservable;

	public static int maxSize = 63;

	public static int goalX;
	public static int goalY;

	public static int enemyX;
	public static int enemyY;
	private int enemyZ;

	// Use this for initialization
	void Start () {

		enemyActive = true;
		isDiscrete = true;
		isObservable = true;

		obsToggle = GameObject.FindGameObjectWithTag ("ObservableToggle").GetComponent<Toggle> ();
		disToggle = GameObject.FindGameObjectWithTag ("DiscreteToggle").GetComponent<Toggle> ();

		InstantiateGrid ();

	}
		
		
	void InstantiateGrid() {

		goalX = maxSize/2; // Middle of Grid
		goalY = maxSize/2; // Middle of Grid

		enemyX = maxSize - 1; // Opposite end of Grid from player
		enemyY = maxSize - 1; // Opposite end of Grid from player
		enemyZ = -5;

		// Instantiates all tiles on the Grid.
		for (int x = 0; x < maxSize; x++) {
			for (int y = 0; y < maxSize; y++) {

				Vector3 tilePosition = new Vector3 (x, y, transform.position.z);

				if ((x == goalX) && 
					(y == goalY)) {	
					
					Instantiate (Goal, tilePosition, transform.rotation); // Spawn Goal

				} else if ((Random.value <= 0.21) &&
						  (x != 0 || y != 0) &&
						  (x != maxSize || y != maxSize) &&
						  (x != enemyX || y != enemyY)) {	
					
					Instantiate (Hole, tilePosition, transform.rotation); // Spawn Hole

				} else {	
					

					if (enemyActive &&
						x == enemyX &&
						y == enemyY) {

						Vector3 ePosition = new Vector3 (x, y, enemyZ);
						Instantiate (Enemy, ePosition, transform.rotation); // Spawn Enemy

					}

					Instantiate (Tile, tilePosition, transform.rotation); // Spawn Tile

				}

			}
		}

	}

	// Update is called once per frame
	void Update () {

		if (obsToggle.isOn) {
			isObservable = true;
		} else {
			isObservable = false;
		}

		if (disToggle.isOn) {
			isDiscrete = true;
		} else {
			isDiscrete = false;
		}

	}
}
