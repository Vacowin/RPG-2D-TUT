using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movingSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * movingSpeed * Time.deltaTime,0.0f,0.0f));
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * movingSpeed * Time.deltaTime, 0.0f));
        }
    }
}
