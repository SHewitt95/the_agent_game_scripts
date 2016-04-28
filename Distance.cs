using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Distance : MonoBehaviour {

	private static Text distanceUI;

	// Use this for initialization
	void Start () {

		distanceUI = GameObject.FindGameObjectWithTag("Distance").GetComponent<Text>();


	}

	// Update is called once per frame
	void Update () {

		distanceUI.text = string.Format("{000}", DistanceCalculator.getDistance());

	}


}
