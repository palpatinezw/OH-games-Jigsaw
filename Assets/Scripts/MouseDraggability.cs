using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(BoxCollider))]
 
public class MouseDraggability : MonoBehaviour {
 	
	public GameObject lockTrigger; //object used to determine when to Lock the puzzle piece to a point
	public Vector3 lockTriggerOffset = new Vector3(0.0f, -0.8f, 0.0f); // position offset of the lock trigger from the main puzzle piece object (0, -0.8, 0)
	public int answer;

 	private Vector3 offset;
 	private Vector3 screenPoint;
 	private bool locked = false;
 	private bool paused = false;

 	private Vector3 initPos;

 	void Start() {
 		initPos = gameObject.transform.position;
 	}

 	void Reset() {
 		transform.position = initPos;
 		lockTrigger.transform.position = initPos + lockTriggerOffset;
 	}
 	void Pause() {
 		paused = true;
 	}
 	void Resume() {
 		paused = false;
 	}

 	void OnMouseDown()
 	{

     	screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
     	offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 		// for dragging
 	}
 
 	void OnMouseDrag()
 	{
 		if (paused) return;

 		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
 		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
 		// for dragging -> current position is the location of the gameObject based on the mouse cursor location

 		if (locked) {
 			// if locked, only move the trigger and not the piece itself
 			lockTrigger.transform.position = curPosition + lockTriggerOffset;
 			return;
 		}
     	
     	// otherwise move both
     	lockTrigger.transform.position = curPosition + lockTriggerOffset;
 		transform.position = curPosition;
 
 	}

 	public void LockEnter(Vector3 pos) {
 		locked = true;
 		transform.position = pos;
 	}
 	public void LockExit() {
 		if (!locked) return;
 		locked = false;
 		offset = new Vector3(0.0f, 0.0f, 0.0f);
 	}

 
}