using UnityEngine;
using System.Collections;

public class Assassin : NPC {

	// Use this for initialization
	void Start () {
		Debug.Log (this.Name);
		Debug.Log (this.Position[2]);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.Name);
		//Debug.Log (this.Position[2]);
	}

	/*public Assassin(int attackSpeed, int xpGain, int blocking, int hp, int[] position, int damage, int movementSpeed, string attackType, string name)
		:base(attackSpeed, xpGain, blocking, hp, position, damage, movementSpeed, attackType, name){
		
	}*/

	public Assassin()
		:base(2, 1, 2, 10, new int [] {0,0,42}, 3, 0, "hth", "LeAssassin"){

	}
}
