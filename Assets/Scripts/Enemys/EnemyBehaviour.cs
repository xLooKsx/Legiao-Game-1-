using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour 
{

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
	public enemyPowerBehaviout powerPrefab;
	private float currentRateToPower;
	public float powerRate;
	public bool canAttack;
	public Vector3 offsetPower;

	// Use this for initialization
	void Start () 
	{
		leftDirection = mesh.localScale;
		rightDirection = mesh.localScale;
		rightDirection.x *= -1;
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
		startPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		currentRateToPower += Time.deltaTime;

		if(inLeftDirection && isBack){
			transform.Translate(Vector3.left * Time.deltaTime * speed);
			transform.localScale = leftDirection;
		}
		else{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
			transform.localScale = rightDirection;

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
	}
	void Attack()
	{
		if(currentRateToPower >= powerRate){
			currentRateToPower = 0;
			GameObject projectil = Instantiate(powerPrefab.gameObject, transform.position+offsetPower, transform.rotation) as GameObject;
			projectil.GetComponent<enemyPowerBehaviout>().right = !isBack;
		}
	}

	}
