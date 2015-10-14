using UnityEngine;
using System.Collections;

public abstract class Dragonet : NPC {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public Dragonet(int attackSpeed, int xpGain, int blocking, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, damage, movementSpeed, attackType, name){
		
	}
}
