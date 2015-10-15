using UnityEngine;
using System.Collections;

public abstract class Hero : Unit {

	int xpQuantity;
	string handAttack;
	int powerQuantity;
	int hpRefresh;
	int powerRefresh;
	bool defending;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("test");
	}

	public Hero(int xpQuantity, string handAttack, int powerQuantity, int hpRefresh, int powerRefresh, bool defending, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(hp, damage, movementSpeed, attackType, name){
		XpQuantity = xpQuantity;
		HandAttack = handAttack;
		PowerRefresh = powerRefresh;
		HpRefresh = hpRefresh;
		PowerRefresh = powerRefresh;
	}

	public int XpQuantity {
		get {
			return this.xpQuantity;
		}
		set {
			xpQuantity = value;
		}
	}

	public string HandAttack {
		get {
			return this.handAttack;
		}
		set {
			handAttack = value;
		}
	}

	public int PowerQuantity {
		get {
			return this.powerQuantity;
		}
		set {
			powerQuantity = value;
		}
	}

	public int HpRefresh {
		get {
			return this.hpRefresh;
		}
		set {
			hpRefresh = value;
		}
	}

	public int PowerRefresh {
		get {
			return this.powerRefresh;
		}
		set {
			powerRefresh = value;
		}
	}

	bool Defending {
		get {
			return this.defending;
		}
		set {
			defending = value;
		}
	}

	public override void Run()
	{
		this.transform.position += new Vector3(0,0,base.MovementSpeed);
	}

	void DefenseMode(){
		if (Defending) {
			Defending = false;
		} else {
			Defending = true;
		}
	}
}
