using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Leap;

public class LeapControl : MonoBehaviour {
	
	public enum ActionState
	{
		ATTACK,
		DEFENSE,
		CHEST,
		REST
	}
	
	
	private float timeAction;
	
	public ActionState actionState = ActionState.REST;
	
	public Vector3 initShieldPosition; //a mettre dans game controller
	public Vector3 initSwordPosition; //a mettre dans game controller
	
	/** The underlying Leap Motion Controller object.*/
	protected Controller leap_controller_;
	
	public Canvas debugLeapCanvasPrefab;
	private Canvas debugLeapCanvas;
	
	protected UnityEngine.UI.Text leapDebugLabel;
	protected UnityEngine.UI.Text movementLabel;
	
	
	public GameObject  attackProjectionPrefab ;
	private GameObject attackProjection;
	public GameObject  defenseProjectionPrefab ;
	private GameObject defenseProjection;
	
	public GameObject pointerAttackHandPrefab;
	private GameObject pointerAttackHand;
	public GameObject pointerDefenseHandPrefab;
	private GameObject pointerDefenseHand;

	public GameObject dbgSphere;
	public GameObject debugSphereObject;

	Hand rightHand = null;
	Hand leftHand = null;
	
	float movementScale = 15f;
	
	GameObject heroAsParent;
	
	
	private int nAction = 0;

	//TODO overwritte with game settigns
	private GameController.HandSide attackHand = GameController.HandSide.RIGHT_HAND; //default value
	private GameController.HandSide defenseHand = GameController.HandSide.LEFT_HAND;

	/**
	 * Sets which hand (right or left) is the attack hand.
	 * At the same time, defines which defense hand it is (by inverse logic).
	 * It means you don't have to call both setAttackHand or setDefenseHand
	 **/
	public void setAttackHand(GameController.HandSide attackSide)
	{
		attackHand = attackSide;
		defenseHand = (attackSide == GameController.HandSide.RIGHT_HAND ? GameController.HandSide.LEFT_HAND : GameController.HandSide.RIGHT_HAND);

		setInitPosition();
	}

	/**
	 * Sets which hand (right or left) is the attack hand.
	 * At the same time, defines which defense hand it is (by inverse logic)
	 * It means you don't have to call both setAttackHand or setDefenseHand
	 **/
	public void setDefenseHand(GameController.HandSide defenseSide)
	{
		attackHand = (defenseSide == GameController.HandSide.RIGHT_HAND ? GameController.HandSide.LEFT_HAND : GameController.HandSide.RIGHT_HAND);
		defenseHand = defenseSide;

		setInitPosition();


	}

	private void setInitPosition()
	{
		//switch init pos if lefthanded
		if (attackHand == GameController.HandSide.RIGHT_HAND)
		{
			pointerDefenseHand.transform.localPosition = new Vector3 (-1.65f, -0.25f, 0.1f);
			pointerAttackHand.transform.localPosition = new Vector3(1.65f, -0.25f, 0.1f);
		}
		else
		{
			pointerDefenseHand.transform.localPosition = new Vector3 (1.65f, -0.25f, 0.1f);
			pointerAttackHand.transform.localPosition = new Vector3(-1.65f, -0.25f, 0.1f);
		}
		
		initShieldPosition = pointerDefenseHand.transform.localPosition;
		initSwordPosition = pointerAttackHand.transform.localPosition;
		
		//same init pos
		defenseProjection.transform.position = pointerDefenseHand.transform.position;
		attackProjection.transform.position = pointerAttackHand.transform.position;
	}

	/**
	 * Returns the Vector 3 Position of the LeapMotion right or left hand (according to
	 * setAttackHand)
	 * internals pointerDefenseHand/pointerAttackHand must be already initialized
	 * internal attackHand must be set with setAttackHand() first
	 **/
	public Vector3 getAttackPointer()
	{
		return pointerAttackHand.transform.position;
	}

	/**
	 * Returns the Vector 3 Position of the LeapMotion right or left hand (according to
	 * setAttackHand)
	 * internals pointerDefenseHand/pointerAttackHand must be already initialized
	 * internal attackHand must be set with setAttackHand() first
	 **/
	public Vector3 getDefensePointer()
	{
		return pointerDefenseHand.transform.position;
	}

	// Use this for initialization
	/**
	 * Called before GameController calls LeapControl.setParent()
	 **/
	void OnEnable () 
	{
		debugSphereObject = Instantiate (dbgSphere);

		debugLeapCanvas = Instantiate (debugLeapCanvasPrefab);
		attackProjection = Instantiate (attackProjectionPrefab);
		defenseProjection = Instantiate (defenseProjectionPrefab);
		
		pointerDefenseHand = Instantiate (pointerDefenseHandPrefab);
		pointerAttackHand = Instantiate (pointerAttackHandPrefab);

		leapDebugLabel = debugLeapCanvas.transform.Find("InfoLabel").GetComponent<UnityEngine.UI.Text>();
		movementLabel = debugLeapCanvas.transform.Find("MovementLabel").GetComponent<UnityEngine.UI.Text>();


		//setAttackHand(GameController.HandSide.RIGHT_HAND);
	
		Debug.Log ("Fin de Start LeapControl.cs ");
		
	}
	
	public void addParent(GameObject go)
	{
		heroAsParent = go;
		Debug.Log("add parent: "+go);
		pointerDefenseHand.transform.parent = go.transform;
		pointerAttackHand.transform.parent = go.transform;
		attackProjection.transform.parent = go.transform;
		defenseProjection.transform.parent = go.transform;
	}
	
	/** Creates a new Leap Controller object. */
	void Awake()
	{
		leap_controller_ = new Controller();
		Debug.Log("Awake, new Controller:"+leap_controller_);

		//leap_controller_.
	}
	
	/**
	 * using rightHand and leftHand var 
	 **/
	void GestureDetection(Hand hand)
	{

		//detect gestures
		//detect hand forward (attack / defense)
		if (hand != null && hand.IsValid && (hand.PalmPosition.z <= -50) && (hand.PalmVelocity.z <= -500))
		{
			if ((attackHand == GameController.HandSide.LEFT_HAND && hand.IsLeft) || 
			    (attackHand == GameController.HandSide.RIGHT_HAND && hand.IsRight))
				nAction = attack(nAction, hand);
			else
				nAction = defense(nAction);
		}

	}

	/**
	 * return nAction
	 **/
	public int attack (int nAction, Hand hand)
	{
		nAction++;
		//dbg pps
		
		//attackProjection.GetComponent<Renderer>().enabled = true;
		
		Vector3 pointerPosition = attackProjection.transform.position;
		pointerPosition.x = hand.PalmPosition.ToUnityScaled().x * movementScale;
		pointerPosition.y = hand.PalmPosition.ToUnityScaled().y * movementScale;
		attackProjection.transform.position = pointerPosition;
		
		actionState = ActionState.ATTACK;
		timeAction = Time.time;

		return nAction;
	}

	public int defense(int nAction)
	{
		nAction++;
		
		
		defenseProjection.GetComponent<Renderer>().enabled = true;
		
		//reattach shield  to pointer
		defenseProjection.transform.parent = pointerDefenseHand.transform;
		defenseProjection.transform.localPosition = new Vector3(0,0,0);
		
		/*Vector3 pointerPosition = defenseProjection.transform.localPosition;
			pointerPosition.x = leftHand.PalmPosition.ToUnityScaled().x * movementScale;
			pointerPosition.y = leftHand.PalmPosition.ToUnityScaled().y * movementScale;
			defenseProjection.transform.localPosition = pointerPosition;*/
		
		
		
		actionState = ActionState.DEFENSE;
		timeAction = Time.time;

		return nAction;
	}
	
	public ActionState getActionState() {
		return actionState;
	}

	Leap.Vector leapToWorld(Leap.Vector leapPoint, InteractionBox iBox)
	{
		leapPoint.z *= -1.0f; //right-hand to left-hand rule
		Leap.Vector normalized = iBox.NormalizePoint(leapPoint, false);
		normalized += new Leap.Vector(0.5f, 0f, 0.5f); //recenter origin
		return normalized * 100.0f; //scale
	}

	
	// Update is called once per frame
	void Update () 
	{
		
		if(leap_controller_.IsConnected && leap_controller_.IsServiceConnected())
		{
			string frameString;
			
			//polling de LM
			Frame frame = leap_controller_.Frame();

			/*InteractionBox iBox = frame.InteractionBox;
			iBox.*/

			float appWidth = Camera.allCameras[0].pixelWidth;
			float appHeight = Camera.allCameras[0].pixelHeight;

			Debug.Log("Camera Pixel Size:"+Camera.allCameras[0].pixelWidth+";"+Camera.allCameras[0].pixelHeight);
			
			InteractionBox iBox = frame.InteractionBox;
			Pointable pointable = frame.Pointables.Frontmost;
			
			Leap.Vector leapPoint = pointable.StabilizedTipPosition;
			//Leap.Vector normalizedPoint = iBox.NormalizePoint(leapPoint, false);

			Leap.Vector t = leapToWorld(leapPoint, iBox);

			
			/*float appX = normalizedPoint.x * appWidth;
			float appY = (1 - normalizedPoint.y) * appHeight;

			Leap.Vector test = new Leap.Vector(appX, 4000+appY, 0.10f);*/
			Vector3 testU = t.ToUnityScaled();
			testU.z = 4;

			//frameString = "x:"+appX+" ; y:"+ appY;
			frameString = "vector3( "+testU.x+" ; " +testU.y+" ; "+testU.z+" )";

			dbgSphere.transform.position = testU;




			/** normal code
			

			
			//debug info
			frameString = "frame_id" + frame.Id;
			frameString += "\nnum_hands" +  frame.Hands.Count;
			frameString += "\nnum_fingers" + frame.Fingers.Count;
			frameString += "\num_fingers" + frame.Fingers.Count;
			
			HandList handsInFrame = frame.Hands;
			
			
			foreach (Hand hand in handsInFrame)
			{
				
				
				if (hand.IsValid && (hand.IsLeft && defenseHand == GameController.HandSide.LEFT_HAND ||
				    hand.IsRight && defenseHand == GameController.HandSide.RIGHT_HAND))
				{
					frameString += "\nLeft hand";
					frameString += "\nLeft hand pos.x :  " + hand.PalmPosition.x;
					frameString += "\nLeft hand postounityscale.x :  " + hand.PalmPosition.ToUnityScaled().x;
					frameString += "\nLeft pointer pos :  " + pointerDefenseHand.transform.position.ToString();
					leftHand = hand;
					//pointerDefenseHand.transform.localPosition = leftHand.PalmPosition.ToUnityScaled();
					Vector3 pointerPosition = pointerDefenseHand.transform.position;
					pointerPosition.x = leftHand.PalmPosition.ToUnityScaled().x * movementScale;
					pointerPosition.y = leftHand.PalmPosition.ToUnityScaled().y * movementScale;
					pointerDefenseHand.transform.position = pointerPosition;
					
				}
				else if (hand.IsValid && (hand.IsRight && attackHand == GameController.HandSide.RIGHT_HAND ||
				         hand.IsLeft && attackHand == GameController.HandSide.LEFT_HAND))
				{
					
					rightHand = hand;
					//pointerAttackHand.transform.localPosition = rightHand.PalmPosition.ToUnityScaled();
					
					Vector3 pointerPosition = pointerAttackHand.transform.position;
					pointerPosition.x = rightHand.PalmPosition.ToUnityScaled().x * movementScale;
					pointerPosition.y = rightHand.PalmPosition.ToUnityScaled().y * movementScale;
					pointerAttackHand.transform.position = pointerPosition;
					
				}

				//ne cherche les actions que si on est pas déjà en mvt
				if(actionState == ActionState.REST)
					GestureDetection (hand);
				
			}
			*/
			leapDebugLabel.text = frameString;
			
		}
		else
			//leap not available
		{
			string frameString = ("Leap Service: "+leap_controller_.IsServiceConnected());
			frameString += "\nLeap Connected:"+leap_controller_.IsConnected;
			frameString += "\nswitching to keyboard/mouse mode.";
			
			leapDebugLabel.text = frameString;
		}
		

		movementLabel.text = actionState.ToString() + " ( "+ nAction.ToString()+" )";
	}

	/**
	 * Remet les projections mains gauche et main droite dans leur position de repos (vers le bas de l'écran).
	 * En général, a appeler quand on respasse l'actionState à REST
	 **/
	public void backToInitialPosition()
	{
		//remet en état initial la main gauche
		defenseProjection.transform.parent = heroAsParent.transform;
		Vector3 restPositionL = defenseProjection.transform.position;
		restPositionL.x = initShieldPosition.x;
		restPositionL.y = initShieldPosition.y;
		
		defenseProjection.transform.position =  restPositionL;

		Vector3 restPositionR = attackProjection.transform.position;
		restPositionR.x = initSwordPosition.x;
		restPositionR.y = initSwordPosition.y;
		attackProjection.transform.position = restPositionR;
	}
	
}

