using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour {

	float maxHp, currentHp = 100;

	public bool canTakeDame = true;
	public Image healthBar;
	PlayerController pController;

	// Use this for initialization
	void Start () {
		pController = GetComponent<PlayerController> ();
		if (pController == null)
			Debug.LogError ("PlayerController not founded!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage){
		if (!canTakeDame)
			return;
		
		currentHp -= damage;
		//Death
		if (currentHp <= 0) {
		
		}

		healthBar.fillAmount = currentHp / maxHp;

	}
}
