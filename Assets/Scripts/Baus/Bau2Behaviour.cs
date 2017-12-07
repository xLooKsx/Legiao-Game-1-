using UnityEngine;
using System.Collections;

public class Bau2Behaviour : MonoBehaviour {
	
	public string[] questions;
	public string[] answers;
	bool displayDialog = false;
	public Vector3 dialogBox;
	public float dialogWidth;
	public float dialogtHeigth;
	
	public bool fistQuestion;
	public bool secondQuestion;
	public bool thirdQuestion;

	private MK_Dialog_03 MK_Dialog;
	
	private PlayerBehaviour player;

	public bool visivel;
	
	// Use this for initialization
	void Start () 
	{
		fistQuestion = true;
		secondQuestion = false;
		thirdQuestion = false;
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
		MK_Dialog = FindObjectOfType (typeof(MK_Dialog_03)) as MK_Dialog_03;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnGUI()
	{
		if (visivel)
		{
			GUILayout.BeginArea (new Rect (dialogBox.x, dialogBox.y, dialogWidth, dialogtHeigth));
			if (displayDialog) 
			{
				if (fistQuestion == true) 
				{
					GUILayout.Label(questions[0]);
					if(GUILayout.Button(answers[0]))
					{
						fistQuestion = false;
						secondQuestion = true;
					}
					if(GUILayout.Button(answers[1]))
					{
						displayDialog = false;
					}
				}
				if (secondQuestion ==true) 
				{
					GUILayout.Label(questions[1]);
					if(GUILayout.Button(answers[2]))
					{
						secondQuestion = false;
						thirdQuestion = true;
						displayDialog = false;
						player.canAttack = true;
						player.canCure = true;
						PlayerStatsController.mpPotion=5;
						MK_Dialog.secondQuestion=true;
						
						
						
					}
				}
				if (thirdQuestion ==true) 
				{
					GUILayout.Label(questions[2]);
				}
				
				
			}
			GUILayout.EndArea ();
		}
	}
	void OnTriggerEnter()
	{
		displayDialog = true;
	}
	void OnTriggerExit()
	{
		displayDialog = false;
	}
}
