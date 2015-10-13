using UnityEngine;
using System.Collections;



public class UnitScene : MonoBehaviour {

	public GameObject warrior;
	public GameObject dragonet;

	// Use this for initialization
	void Start () {

		//warrior = new Warrior(0,"epee",100, 5, 0, false, 500,  new int [] {10, 0, 12}, 12, 3, "CAC", "Bob");
		Instantiate(warrior, new Vector3(0, 0, 0), Quaternion.identity);
		Instantiate(dragonet, new Vector3(3, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
