using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f;
	public float maxVLC = 4f;

	[SerializeField]
	private Rigidbody2D myBody;
	private Animator anim;

	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
		
	}
	 
	void FixedUpdate () {
		PlayerMoveKeyboard ();
	}

	void PlayerMoveKeyboard() {
		float moveX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal"); 

		if (h > 0) {

			if (vel < maxVLC)
				moveX = speed;

			Vector3 temp = transform.localScale;
			temp.x = 2f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
	
		} else if (h < 0) {

			if (vel < maxVLC)
				moveX = -speed;

			Vector3 temp = transform.localScale;
			temp.x = -2f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
		} else {

			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2(moveX, 0));
	}
}
