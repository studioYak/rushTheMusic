using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

	int hp;
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

	void Update(){
		Debug.Log ("test");
	}

	public Unit(int hp, int damage, int movementSpeed, string attackType, string name){
		this.hp = hp;
		this.damage = damage;
		this.movementSpeed = movementSpeed;
		this.attackType = attackType;
		this.name = name;
	}

	public int HealthPoint {
		get {
			return this.hp;
		}
		set {
			hp = value;
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

	void Attack(int x, int y, int z){
		
	}

	public void LostHP(int hpLost){
		hp = hp - hpLost;
	}

	public void SetPosition(int x,int y, int z)
	{
		this.transform.position = new Vector3 (x, y, z);
	}

	public int[] GetPosition()
	{
		int x = this.transform.position.x;
		int y = this.transform.position.y;
		int z = this.transform.position.z;

		return new int[] {x,y,z};
	}

	public abstract void Run ();

	bool IsDead(){
		if (hp <= 0) {
			return true;
		}
		return false;
	}
}
