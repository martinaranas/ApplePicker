using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText		scoreGT;

	void Update () {
		// Get the current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition; //1

		// The Camera's z position sets the how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z; //2

		// Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint ( mousePos2D ) ; // 3

		// Move the x position of this Basket to the x position of the Mouse
		Vector2 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void Start() {
		// Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		// Get the GUIText Component of that GameObject
		scoreGT = scoreGO.GetComponent<GUIText> ();
		// Set the starting number of points to 0
		scoreGT.text = "0";
	}

	void OnCollisionEnter ( Collision coll ) {
		//Find out what his this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		// Parse the text of the scoreGT into an int
		int score = int.Parse(scoreGT.text);
		// Add points for catching the apple
		score += 100;
		// Convert the score back to a string and display it
		scoreGT.text = score.ToString();
	}
}
