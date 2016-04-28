using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	Vector3 pos;                                // For movement
	float speed = 2.0f;                         // Speed of movement

	private static int currentX;					// Current x position
	private static int currentY;					// Current y position

	public float leftBound = 0;
	public float rightBound;
	public float upperBound;
	public float lowerBound = 0;


	void Start () {
		pos = transform.position;          // Take the initial position

		rightBound = Grid.maxSize-1;
		upperBound = Grid.maxSize-1;

		currentX = 0;
		currentY = 0;
	}


	void Update () {

		if (Grid.isDiscrete) {
			MoveDiscrete ();
		} else {
			MoveContinuous ();
		}

		if (Grid.isObservable) {
			cameraOut ();
		} else {
			cameraIn ();
		}
			
	}
		

	void cameraIn() {
		Camera.main.orthographicSize = 0.75f;
	}

	void cameraOut() {
		Camera.main.orthographicSize = 1.5f;
	}


	void MoveDiscrete() {

		/*
		 * Grid-style movement: http://answers.unity3d.com/answers/892128/view.html
		 * Added features: 
		 * ...Preventing movement when Grid bounds are reached.
		 * ...Incrementing the player's X and Y coordinates accordingly.
		 * ...Abstracting the code to a separate method.
		 */

		if(Input.GetKey(KeyCode.A) && transform.position == pos) {        // Left
			if (pos.x != leftBound) {
				pos += Vector3.left;
				currentX--;
			}
		}
		if(Input.GetKey(KeyCode.D) && transform.position == pos) {        // Right
			if (pos.x != rightBound) {
				pos += Vector3.right;
				currentX++;
			}
		}
		if(Input.GetKey(KeyCode.W) && transform.position == pos) {        // Up
			if (pos.y != upperBound) {
				pos += Vector3.up; 
				currentY++;
			}
		}
		if(Input.GetKey(KeyCode.S) && transform.position == pos) {        // Down
			if (pos.y != lowerBound) {
				pos += Vector3.down;
				currentY--;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there

	}


	void MoveContinuous() {
		if (Input.GetKey(KeyCode.A))
		{
			MoveHorizontal();
		}

		if (Input.GetKey(KeyCode.D))
		{
			MoveHorizontal();
		}

		if (Input.GetKey(KeyCode.W))
		{
			MoveVertical();
		}

		if (Input.GetKey(KeyCode.S))
		{
			MoveVertical();
		}

		setCoordinate (transform.position);
	}


	void MoveHorizontal()
	{
		if (transform.position.x >= leftBound && transform.position.x <= rightBound)
		{
			Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			transform.position += move * speed * Time.deltaTime;
		} else if (transform.position.x < leftBound)
		{

			float adjust = 0.01f;
			float newPos = transform.position.x + adjust;
			transform.position = new Vector3(newPos, transform.position.y, transform.position.z);

		} else
		{

			float adjust = -0.01f;
			float newPos = transform.position.x + adjust;
			transform.position = new Vector3(newPos, transform.position.y, transform.position.z);

		}
	}


	void MoveVertical()
	{
		if (transform.position.y >= lowerBound && transform.position.y <= upperBound)
		{
			Vector3 move = new Vector3(0, Input.GetAxis("Vertical"), 0);
			transform.position += move * speed * Time.deltaTime;
		}
		else if (transform.position.y < lowerBound)
		{

			float adjust = 0.01f;
			float newPos = transform.position.y + adjust;
			transform.position = new Vector3(transform.position.x, newPos, transform.position.z);

		}
		else
		{

			float adjust = -0.01f;
			float newPos = transform.position.y + adjust;
			transform.position = new Vector3(transform.position.x, newPos, transform.position.z);

		}
	}


	void setCoordinate(Vector3 position) {
		currentX = (int)position.x;
		currentY = (int)position.y;
	}


	public static int getX() {
		return currentX;
	}


	public static int getY() {
		return currentY;
	}


	void OnCollisionEnter2D(Collision2D obj)
	{
		SceneManager.LoadScene("Agent"); // Reloads the level.
	}


}
