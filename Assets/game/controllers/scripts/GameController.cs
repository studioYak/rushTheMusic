using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class GameController : MonoBehaviour {

	public GameObject terrain;

	public GameObject basicLancer;
	public GameObject basicDragonet;

	private GameObject ter;

	private float vitesseHeros = 5.0f;
	private float tempsMusique = 240f;

	private List<GameObject> npcList;

	private int timerBloque = 0;
	private int maxTimerBloque = 5*60;

	private bool bloque = false;
	// Use this for initialization
	void Start () {
		//lire fichier niveau

		//Génération de terrain
		float longueurTerrain = vitesseHeros * tempsMusique;

		ter = Instantiate( terrain, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		ter.transform.Rotate (0, -90, 0);
		ter.transform.localScale = new Vector3 (longueurTerrain, 1, 1);

		//génération des ennemis
		npcList = new List<GameObject> ();
		npcList.Add( Instantiate(basicLancer, new Vector3(0, 0, vitesseHeros*20), Quaternion.identity) as GameObject);
		npcList.Add( Instantiate(basicLancer, new Vector3(0, 0, vitesseHeros*30), Quaternion.identity) as GameObject);
		npcList.Add( Instantiate(basicDragonet, new Vector3(0, 0, vitesseHeros*50), Quaternion.identity) as GameObject);

	}
	
	// Update is called once per frame
	void Update () {

		//Gestion héros
		if (!bloque) {
			//faire avancer Héros
			Camera.allCameras[0].transform.Translate(Vector3.forward * Time.deltaTime * vitesseHeros, Space.World);
		}

		//Gestion premier ennemi
		if (npcList.Count != 0) {
			NPC firstNPC = npcList [0].GetComponent<NPC> ();

			float distance = (firstNPC.transform.position.z - Camera.allCameras [0].transform.position.z);
			Debug.Log (distance);

			if (!bloque) {




				//avancer si aggro
				if (distance < 50) {
					npcList [0].transform.Translate(new Vector3 (0, 0, -1) * Time.deltaTime * (float)firstNPC.MovementSpeed, Space.World);
					firstNPC.SetPosition (firstNPC.GetPosition () [0], 1.0f, firstNPC.GetPosition () [2]);
				}

				if (distance < 10) {
					bloque = true;
				}
			}


		}

		




		if (bloque) {
			timerBloque++;

			if (timerBloque >= maxTimerBloque) {
				bloque = false;
				timerBloque = 0;
				npcList.RemoveAt(0);
			}
		}

	}
	
}
