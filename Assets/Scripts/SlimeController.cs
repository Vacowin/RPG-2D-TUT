using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidBody;

	private bool moving;

	public Vector3 moveDirection;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	public float timeToMove;
	private float timeToMoveCounter;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;
			if (timeToMoveCounter <= 0) {
				moving = false;
				timeToMoveCounter = timeToMove;
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter <= 0) {
				moving = true;
				timeBetweenMoveCounter = timeBetweenMove;
				moveDirection = (new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f), 0)) * moveSpeed;
			}
		}
	}
}
