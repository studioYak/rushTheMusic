using UnityEngine;
using System.Collections;

public class IceLancer : Lancer {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IceLancer(int attackSpeed, int xpGain, int blocking, int hp, int[] position, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, position, damage, movementSpeed, attackType, name){

	}
}
