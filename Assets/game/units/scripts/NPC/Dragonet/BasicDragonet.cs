using UnityEngine;
using System.Collections;

public class BasicDragonet : Dragonet {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.green;
		gameObject.tag = "weapon";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public BasicDragonet(int attackSpeed, int xpGain, int blocking, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, damage, movementSpeed, attackType, name){
		
	}
}

