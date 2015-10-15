using UnityEngine;
using System.Collections;

public class Assassin : NPC {

	// Use this for initialization
	void Start () {
		Debug.Log (this.Name);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.Name);
		//Debug.Log (this.Position[2]);
	}

	public Assassin(int attackSpeed, int xpGain, int blocking, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, damage, movementSpeed, attackType, name){
		
	}
}
