using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLockScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
    	if (collision.gameObject.tag == "Location" && !collision.gameObject.GetComponent<LockScript>().locked) {
    		Vector3 pos = collision.gameObject.transform.position;
    		GameObject puzzlepiece = gameObject.transform.parent.gameObject;
    		puzzlepiece.GetComponent<MouseDraggability>().LockEnter(new Vector3(pos.x, 5.0f, pos.z));
    		collision.gameObject.GetComponent<LockScript>().LockEnter();
    	}
    }
    void OnCollisionExit(Collision collision) {
    	if (collision.gameObject.tag == "Location") {
    		GameObject puzzlepiece = gameObject.transform.parent.gameObject;
    		puzzlepiece.GetComponent<MouseDraggability>().LockExit();
    		collision.gameObject.GetComponent<LockScript>().LockExit();
    	}
    }
}
