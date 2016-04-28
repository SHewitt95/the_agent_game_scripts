using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {

	Vector3 pos;                                // For movement
	float speed = 2.0f;                         // Speed of movement

	private int currentX;					// Current x position
	private int currentY;					// Current y position

	private float leftBound = 0;
	private float rightBound;
	private float upperBound;
	private float lowerBound = 0;

	private bool moveDown;


	void Start () {
		pos = transform.position;          // Take the initial position

		rightBound = Grid.maxSize-1;
		upperBound = Grid.maxSize-1;

		currentX = Grid.enemyX;
		currentY = Grid.enemyY;

		moveDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {

		if (moveDown && transform.position == pos) { 					  // Down
			if (pos.y != lowerBound) {
				pos += Vector3.down;
				currentY--;
			}
		} else if (transform.position == pos) { 						  // Left
			if (pos.x != leftBound) {
				pos += Vector3.left;
				currentX--;
			}
		}

		moveDown = !moveDown;

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		
		if (obj.gameObject.tag == "Goal") {
			SceneManager.LoadScene("Agent"); // Reloads the level.
		}

		if (obj.gameObject.tag == "Hole") {
			Destroy(gameObject); // Destroys the Character.
		}
			
	}
}
