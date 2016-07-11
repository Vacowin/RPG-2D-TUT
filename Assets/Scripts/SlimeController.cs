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

	public float waitToReload;
	private bool reloading;

	private GameObject player;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);

		reloading = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;
			if (timeToMoveCounter <= 0) {
				moving = false;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter <= 0) {
				moving = true;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
				moveDirection = (new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f), 0)) * moveSpeed;
			}
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload <= 0) {
				Application.LoadLevel (Application.loadedLevel);
				player.SetActive (true);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Player") {
			player = other.gameObject;
			player.SetActive (false);
			reloading = true;
		}
	}
}
