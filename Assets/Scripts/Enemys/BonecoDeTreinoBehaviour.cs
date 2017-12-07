using UnityEngine;
using System.Collections;

public class BonecoDeTreinoBehaviour : MonoBehaviour 
{
	public int totalLife = 10;
	private PlayerBehaviour player;
	private MK_Dialog_04 MK_dialog;

	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
		MK_dialog = FindObjectOfType(typeof(MK_Dialog_04)) as MK_Dialog_04;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider hit)
	{
		if(hit.transform.tag == "Power")
		{
			totalLife--;
			if(totalLife <= 0)
			{
				MK_dialog.golemDie = true;
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
				MK_dialog.golemDie = true;
			}
			Destroy(hit.gameObject);
		}
	}
}
