using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
	public GameObject levelManager; 

	public int answer; // matches the answer with the answer of the locked puzzle piece
	public bool locked = false;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Piece") {
			if (collision.gameObject.GetComponent<MouseDraggability>().answer == answer) levelManager.GetComponent<LevelManagerScript>().SetAnswerCorrect();
		}
	}
	
	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Piece") {
			if (collision.gameObject.GetComponent<MouseDraggability>().answer == answer) levelManager.GetComponent<LevelManagerScript>().SetAnswerWrong();
		}
	}

	public void LockEnter() {
		locked = true;
	}
	public void LockExit() {
		locked = false;
	}
	// private bool correctAns = false; // if the current piece is correct

	// void OnCollisionEnter(Collision collision) {
	// 	if (collision.gameObject.tag == "LockTrigger") {
	// 		// Lock the piece on contacting the trigger
	// 		if (locked) return;
	// 		Debug.Log("locked");
	// 		locked = true;
	//     	curPiece = collision.gameObject.transform.parent.gameObject;
	//     	curPiece.GetComponent<MouseDraggability>().LockEnter(new Vector3(transform.position.x, 5.0f, transform.position.z));
	//     	if (curPiece.GetComponent<MouseDraggability>().answer == answer) {
	//     		correctAns = true;
	//     		levelManager.GetComponent<LevelManagerScript>().SetAnswerCorrect();
	//     		// tells levelManager that 1 correct answer has been scored
	//     	}
	//     	lockedPiece = curPiece;
	// 	}
	// }
	// void OnCollisionExit(Collision collision) {
	// 	if (collision.gameObject.tag == "Piece") curPiece = null;
	// 	else if (collision.gameObject.tag == "LockTrigger") {
	// 		Debug.Log("unlocked");
	// 		locked = false;
	// 		if (correctAns) {
	// 			correctAns = false;
	// 			levelManager.GetComponent<LevelManagerScript>().SetAnswerWrong();
	// 			// tells levelManager that a correct piece has been moved away
	// 		}
	// 		if (lockedPiece == null) {
	// 			Debug.Log("Invalid unlock!");
	// 			return;
	// 		}
	//     	lockedPiece.GetComponent<MouseDraggability>().LockExit();
	//     	lockedPiece = null;
	// 	}
	// }
}
