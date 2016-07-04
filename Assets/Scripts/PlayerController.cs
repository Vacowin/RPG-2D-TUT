using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movingSpeed;
	private bool playerMoving;
	private Vector2 lastMove;

	private Animator anim;
	private Rigidbody2D rigidBody2D;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerMoving = false;

	    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * movingSpeed * Time.deltaTime,0.0f,0.0f));
			rigidBody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movingSpeed, rigidBody2D.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            //transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * movingSpeed * Time.deltaTime, 0.0f));
			rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, Input.GetAxisRaw("Vertical") * movingSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0, Input.GetAxisRaw ("Vertical"));
        }

		if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) < 0.5f) {
			rigidBody2D.velocity = new Vector2(0.0f, rigidBody2D.velocity.y);
		}

		if (Mathf.Abs (Input.GetAxisRaw ("Vertical")) < 0.5f) {
			rigidBody2D.velocity = new Vector2 (rigidBody2D.velocity.x, 0.0f);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
    }
}
