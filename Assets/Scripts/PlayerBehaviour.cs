using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	
	public float speed = 10.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	
	private Vector3 rightDirection;
	private Vector3 leftDirection;
	public Transform mesh;
	
	private CharacterController controller;
	private AnimationController AnimationController;

	public Transform powerPrefab;
	public float powerRate = 0.5f;
	private float currentRateToPower = 0;
	private bool directionPlayerRight = true;

	public Transform mellePrefab;
	public float powerRateMelle = 0.5f;
	private float currentRateToPowerMelle = 0;

	public float mpRecoveryRate = 10;
	public float currentMpRecoveryRate;
	public float hpRecoveryRate = 10;
	public float currentHpRecoveryRate;

	public bool canMove = true;
	public bool canAttack = true;
	public bool canCure = true;

	public Vector3 SMSpeed;
	
	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
		AnimationController = GetComponent<AnimationController>();

		rightDirection = mesh.localScale;
		leftDirection = mesh.localScale;
		leftDirection.z *= -1;
		currentRateToPower = powerRate;
		currentRateToPowerMelle = powerRateMelle;

		canMove = true;
		canAttack = true;
		canCure = true;

	}
	
	// Update is called once per frame
	void Update ()
	{
		// ta morto?
		if (transform.position.y < -14) 
		{
			CallGameOver ();
		}
		
		if (PlayerStatsController.GetCurrentHp()<=0) 
		{
			CallGameOver();
		}
		// recuperaçao natural de vida e manas
		currentHpRecoveryRate += Time.deltaTime;
		currentMpRecoveryRate += Time.deltaTime;

		if (currentHpRecoveryRate >= hpRecoveryRate) {
			currentHpRecoveryRate = 0;
			if (PlayerStatsController.GetCurrentHp()< PlayerStatsController.maxHp-10) 
			{
				PlayerStatsController.AddHp(PlayerStatsController.GetCurrentHp()+10);
			}
		}

		if (currentMpRecoveryRate >= mpRecoveryRate) {
			currentMpRecoveryRate = 0;
			if (PlayerStatsController.GetCurrentMp()< PlayerStatsController.maxMp-10) 
			{
				PlayerStatsController.AddMp(PlayerStatsController.GetCurrentMp()+10);
			}
		}

		//movimento
		if (canMove) {
			moveDirection.x = Input.GetAxis ("Horizontal") * speed;
			if (controller.isGrounded) {
				moveDirection = new Vector3 (0, 0, Input.GetAxis ("Horizontal"));
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				
				if (Input.GetButton ("Jump")) {
					moveDirection.y = jumpSpeed;
					AnimationController.PlayAnimation (AnimationStates.JUMP);
				}
				
			}
			if (moveDirection == Vector3.zero) {
				AnimationController.PlayAnimation (AnimationStates.IDLE);
			}
			if (moveDirection.x > 0) {
				mesh.localScale = rightDirection;
				AnimationController.PlayAnimation (AnimationStates.WALK);
				directionPlayerRight = true;
			} else if (moveDirection.x < 0) {
				mesh.localScale = leftDirection;
				AnimationController.PlayAnimation (AnimationStates.WALK);
				directionPlayerRight = false;
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
		}

		// ataque
		currentRateToPower += Time.deltaTime;
		if (canAttack) 
		{
			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				if(currentRateToPower >= powerRate && PlayerStatsController.GetCurrentMp()>0)
				{
					currentRateToPower = 0;
					GameObject projectil = Instantiate(powerPrefab.gameObject, (transform.position + new Vector3(0,0,0)), new Quaternion(0,0,0,0)) as GameObject;
					projectil.GetComponent<PowerBehaviour>().right = directionPlayerRight;
					PlayerStatsController.AddMp (PlayerStatsController.GetCurrentMp()-10);
					AnimationController.PlayAnimation (AnimationStates.ATTACK);
					
				}
				
			}
			
			currentRateToPowerMelle += Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.X)) 
			{
				if(currentRateToPowerMelle >= powerRateMelle && PlayerStatsController.GetCurrentMp()>0)
				{
					currentRateToPowerMelle = 0;
					if (mesh.localScale==rightDirection) 
					{
						GameObject projectilMelle = Instantiate(mellePrefab.gameObject, (transform.position + new Vector3(1.5f,0,0)), new Quaternion(0,0,0,0)) as GameObject;
					}
					else
					{
						GameObject projectilMelle = Instantiate(mellePrefab.gameObject, (transform.position + new Vector3(-1.5f,0,0)), new Quaternion(0,0,0,0)) as GameObject;
					}
					PlayerStatsController.AddMp (PlayerStatsController.GetCurrentMp()-10);
					AnimationController.PlayAnimation (AnimationStates.ATTACK);
					
				}
				
			}
		}
		if (canCure) 
		{
			if (Input.GetKeyDown (KeyCode.C)) 
			{
				if (PlayerStatsController.GetCurrentMp() >= 10) 
				{
					if (PlayerStatsController.GetCurrentHp()< PlayerStatsController.maxHp-10)
					{
						PlayerStatsController.AddHp (PlayerStatsController.GetCurrentHp ()+10);
						PlayerStatsController.AddMp (PlayerStatsController.GetCurrentMp ()-10);
					}
				}

			}
		}

	}
	void OnControllerColliderHit(ControllerColliderHit hit) 
	{

		switch (hit.transform.tag) 
		{

			case "Enemy2":
			ApplyDamage (20);
			break;

			default:
						break;
		}

	}
	void applyKnockBack()
	{
		if (directionPlayerRight) 
		{
			controller.SimpleMove (SMSpeed);
		}
		else 
		{
			controller.SimpleMove (SMSpeed);
		}

	}
	public void ApplyDamage(int Damage)
	{
		PlayerStatsController.AddHp (PlayerStatsController.GetCurrentHp()-Damage);
		applyKnockBack();
		if (PlayerStatsController.GetCurrentHp() <=0) 
		{
			CallGameOver();
		}
	}
	void CallGameOver()
	{
		Application.LoadLevel ("GameOver");
	}
}
