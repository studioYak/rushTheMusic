using UnityEngine;
using System.Collections;

public abstract class Lancer : NPC {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Lancer(int attackSpeed, int xpGain, int blocking, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, damage, movementSpeed, attackType, name){
		
	}
}
