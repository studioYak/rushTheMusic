using UnityEngine;
using System.Collections;

public abstract class NPC : Unit {

	int attackSpeed;
	int xpGain;
	int blocking; // 0:free, 1:semi-block, 2:block

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public NPC(int attackSpeed, int xpGain, int blocking, int hp, int[] position, int damage, int movementSpeed, string attackType, string name)
	:base(hp, position, damage, movementSpeed, attackType, name){
		// Debug.Log (this.Hp);
		AttackSpeed = attackSpeed;
		XpGain = xpGain;
		Blocking = blocking;
	}

	public int AttackSpeed {
		get {
			return this.attackSpeed;
		}
		set {
			attackSpeed = value;
		}
	}

	public int XpGain {
		get {
			return this.xpGain;
		}
		set {
			xpGain = value;
		}
	}

	public int Blocking {
		get {
			return this.blocking;
		}
		set {
			blocking = value;
		}
	}


}
