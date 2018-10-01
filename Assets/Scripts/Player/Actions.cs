using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {

	PlayerController pController;

	// Use this for initialization
	void Start () {
		pController = GetComponent<PlayerController> ();
		if (pController == null)
			Debug.LogError ("PlayerController not founded!");
	}
	
	// Update is called once per frame
	void Update () {
		if ((pController.isFirstPlayer && Input.GetAxisRaw ("Fire1") == 1) || (!pController.isFirstPlayer && Input.GetAxisRaw ("Fire2") == 1)) {
			ActionButton ();
		}
	}

	void ActionButton(){

	}
}
