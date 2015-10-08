using UnityEngine;
using System.Collections;

public class Wall : NPC {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Wall(int attackSpeed, int xpGain, int blocking, int hp, int[] position, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, position, damage, movementSpeed, attackType, name){
		
	}

}
