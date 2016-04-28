using UnityEngine;
using System.Collections;

public class DistanceCalculator : MonoBehaviour {

	private static int distance;

	private int goalX;
	private int goalY;


	// Use this for initialization
	void Start () {
		goalX = Grid.goalX;
		goalY = Grid.goalY;
		distance = calculateDistance ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.W) ||
			Input.GetKey(KeyCode.A) ||
			Input.GetKey(KeyCode.S) ||
			Input.GetKey(KeyCode.D)) {

			calculateDistance ();

		}


	}

	int calculateDistance() {

		int x = Movement.getX();
		int y = Movement.getY();

		distance = (((Mathf.Abs(goalX - x)) + (Mathf.Abs(goalY - y))));

		return distance;

	}

	public static int getDistance() {
		return distance;
	}
}
