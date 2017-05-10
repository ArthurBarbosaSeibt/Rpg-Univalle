using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

public GameObject faderObject;
public GameObject trigger;
private Rigidbody2D rbody;
private Animator anim;
private ScreenFader fader;

// Use this for initialization
void Start () {
	rbody = GetComponent<Rigidbody2D> ();
	anim = GetComponent<Animator> ();
	fader = faderObject.GetComponent<ScreenFader> ();
}

// Update is called once per frame
void FixedUpdate () {
		if (fader.isFading == false && trigger.GetComponent<GatilhoCompartilhado> ().falaTrigger == false) {
			Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

			if (movement_vector != Vector2.zero) {
				anim.SetBool ("iswalking", true);
				anim.SetFloat ("input_x", movement_vector.x);
				anim.SetFloat ("input_y", movement_vector.y);
			} else {
				anim.SetBool ("iswalking", false);			
				rbody.WakeUp ();
			}

			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * 6);
		} else{
			anim.SetBool ("iswalking", false);
		}
}
}

//using UnityEngine;
//using System.Collections;
//
//public class PlayerMovement : MonoBehaviour {
//
//	Rigidbody2D rbody;
//	Animator anim;
//	
//	// Use this for initialization
//	void Start () {
//		rbody = GetComponent<Rigidbody2D> ();
//		anim = GetComponent<Animator> ();
//	}
//
//	// Update is called once per frame
//	void FixedUpdate () {
//		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
//		if ( movement_vector != Vector2.zero )
//		{
//			anim.SetBool("iswalking", true);
//			anim.SetFloat("input_x", movement_vector.x);
//			anim.SetFloat("input_y", movement_vector.y);
//		}
//		else 
//		{
//			anim.SetBool("iswalking", false);
//		}
//
//		rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * 300);
//
//	}
//}﻿
