using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool isFirstPlayer;

	float speed = 5;
	Vector3 velocity = Vector3.zero;
	float gravity = -80f;

	CharacterController cc;
	bool isGrounded;
	public Transform groundChecker;
	float groundDistance = 0.3f;
	[SerializeField]
	LayerMask layerMask;

	float jumpHeight = 3f;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		if (cc == null)
			Debug.LogError ("CharacterController not founded!");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move;
		if (isFirstPlayer) {
			move = new Vector3(Input.GetAxis ("Horizontal"),0,Input.GetAxis ("Vertical"));
		}else{
			move = new Vector3(Input.GetAxis ("Horizontal2"),0,Input.GetAxis ("Vertical2"));
		}
		move = transform.TransformDirection (move);
		cc.Move(move*speed*Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;
		cc.Move (velocity * Time.deltaTime);

		isGrounded = Physics.CheckSphere (groundChecker.position,groundDistance,layerMask);
		if (isGrounded && velocity.y < 0)
			velocity.y = 0;

		if (isGrounded) {
			if ((Input.GetAxisRaw ("Jump") == 1 && isFirstPlayer) || (Input.GetAxisRaw ("Jump2") == 1 && !isFirstPlayer)) {
				velocity.y += Mathf.Sqrt (jumpHeight *-2 * gravity);
			}
		}

	}
}
