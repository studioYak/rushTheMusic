using UnityEngine;
using System.Collections;

public class FireDragonet : Dragonet {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public FireDragonet(int attackSpeed, int xpGain, int blocking, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, damage, movementSpeed, attackType, name){

	}
}
