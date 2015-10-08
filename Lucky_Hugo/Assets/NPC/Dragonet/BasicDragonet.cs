using UnityEngine;
using System.Collections;

public class BasicDragonet : Dragonet {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public BasicDragonet(int attackSpeed, int xpGain, int blocking, int hp, int[] position, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, position, damage, movementSpeed, attackType, name){

	}
}

