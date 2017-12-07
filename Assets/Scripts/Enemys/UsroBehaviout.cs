using UnityEngine;
using System.Collections;

public class UsroBehaviout : MonoBehaviour {

	public int totalLife = 2;
	private PlayerBehaviour player;
	public Transform caindoEnemy;
	
	public Vector3 startPosition;
	public Vector3 finalPosition;
	private Vector3 rightDirection;
	private Vector3 leftDirection;
	
	public Transform mesh;
	
	public float speed = 7f;
	public bool inLeftDirection = true;
	private bool isBack = true;
	
	public float DistanceToAttack;
	public PowerBehaviour powerPrefab;
	private float currentRateToPower;
	public float powerRate;
	public bool canAttack;
	public Vector3 offsetPower;
	private AnimationController AnimationController;
	public BoxCollider collider;

	private bool attacked=false;

	private float melleTimeElapsed=0;
	public float melleDuration=0.3f;


	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
		leftDirection = mesh.localScale;
		rightDirection = mesh.localScale;
		rightDirection.x *= -1;
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
		AnimationController = GetComponent<AnimationController>();

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		currentRateToPower += Time.deltaTime;
		if (attacked == true) 
		{
			melleTimeElapsed+= Time.deltaTime;
		}
		if (melleTimeElapsed>=melleDuration) 
		{
			speed/=2;
			melleTimeElapsed = 0;
			attacked=false;
		}

		if(inLeftDirection && isBack){
			transform.Translate(Vector3.left * Time.deltaTime * speed);
			transform.localScale = leftDirection;
			AnimationController.PlayAnimation (AnimationStates.WALK);

		}
		else{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
			transform.localScale = rightDirection;
			AnimationController.PlayAnimation (AnimationStates.WALK);
			
		}
		
		if(transform.position.x > finalPosition.x){
			inLeftDirection = true;
		}
		else {
			inLeftDirection = false;
			isBack = false;
		}
		
		if(transform.position.x > startPosition.x)
			isBack = true;
		
		float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		if(distanceToPlayer <= DistanceToAttack && canAttack)
			Attack();	
	}
	void OnTriggerEnter(Collider hit)
	{
		if(hit.transform.tag == "Power")
		{
			totalLife--;
			if(totalLife <= 0)
			{
				GameObject projectil = Instantiate(caindoEnemy.gameObject,transform.position,new Quaternion(2,2,2,2)) as GameObject;
				AnimationController.PlayAnimation (AnimationStates.IDLE);
				Destroy(gameObject);
			}
			Destroy(hit.gameObject);
		}
		if(hit.transform.tag == "PowerMelle")
		{
			totalLife-=2;
			if(totalLife <= 0)
			{
				Destroy(gameObject);
			}
			Destroy(hit.gameObject);
		}
		if (hit.transform.tag == "Player") 
		{
			Attack ();
		}
	}

	void Attack()
	{
		if(currentRateToPower >= powerRate){
			currentRateToPower = 0;
			speed*=2;
			attacked= true;
			AnimationController.PlayAnimation (AnimationStates.ATTACK);
			player.ApplyDamage (10);

		}
	}

}
