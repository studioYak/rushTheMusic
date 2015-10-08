using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

	int hp;
	int[] position = new int[3];
	int damage;
	int movementSpeed;
	string attackType;
	string name;

	// Use this for initialization
	void Start () {

		/* pour debug
		   gameObject.GetComponent<Renderer>().material.color = Color.red;
	   */

		
	}

	public Unit(int hp, int[] position, int damage, int movementSpeed, string attackType, string name){
		this.hp = hp;
		this.position = position;
		this.damage = damage;
		this.movementSpeed = movementSpeed;
		this.attackType = attackType;
		this.name = name;
	}

	public int Hp {
		get {
			return this.hp;
		}
		set {
			hp = value;
		}
	}

	public int[] Position {
		get {
			return this.position;
		}
		set {
			position = value;
		}
	}

	public int Damage {
		get {
			return this.damage;
		}
		set {
			damage = value;
		}
	}

	public int MovementSpeed {
		get {
			return this.movementSpeed;
		}
		set {
			movementSpeed = value;
		}
	}

	public string AttackType {
		get {
			return this.attackType;
		}
		set {
			attackType = value;
		}
	}

	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Attack(){

	}

	void LostHP(int hpLost){
		hp = hp - hpLost;
	}

	bool isDie(){
		if (hp <= 0) {
			return true;
		}
		return false;
	}
}
