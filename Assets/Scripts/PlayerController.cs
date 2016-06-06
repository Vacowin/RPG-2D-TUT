using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movingSpeed;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * movingSpeed * Time.deltaTime,0.0f,0.0f));
			Debug.Log ("ahihi");
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * movingSpeed * Time.deltaTime, 0.0f));
        }

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
    }
}
