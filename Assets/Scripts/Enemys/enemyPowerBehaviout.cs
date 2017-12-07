using UnityEngine;
using System.Collections;

public class enemyPowerBehaviout : MonoBehaviour {
	
	public bool right = true;
	public float speed = 1;
	private PlayerBehaviour player;
	
	
	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		if(right)
			transform.Translate(Vector3.right*speed*Time.deltaTime);
		else
			transform.Translate(Vector3.left*speed*Time.deltaTime);
		
	}
	
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
	void OnTriggerEnter(Collider hit)
	{
		if (hit.collider.tag == "Player") 
		{
			player.ApplyDamage (10);
			Destroy(gameObject);
		}
	}
}
