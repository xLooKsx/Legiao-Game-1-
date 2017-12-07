using UnityEngine;
using System.Collections;

public class MK_Dialog_01 : MonoBehaviour {
	public string[] questions;
	public string[] answers;
	bool displayDialog = false;
	public Vector3 dialogBox;
	public float dialogWidth;
	public float dialogtHeigth;
	
	private bool fistQuestion;
	private bool secondQuestion;
	private bool thirdQuestion;
	private bool forthQuestion;
	private PlayerBehaviour player;
	
	// Use this for initialization
	void Start () 
	{
		fistQuestion = true;
		secondQuestion = false;
		thirdQuestion = false;
		forthQuestion = false;
		player = FindObjectOfType (typeof(PlayerBehaviour)) as PlayerBehaviour;
		player.canAttack = false;
		player.canCure = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		GUILayout.BeginArea (new Rect(dialogBox.x, dialogBox.y,dialogWidth,dialogtHeigth));
		if (displayDialog) 
		{
			if (fistQuestion == true) 
			{
				GUILayout.Label(questions[0]);
				if(GUILayout.Button(answers[0]))
				{
					fistQuestion=false;
					secondQuestion = true;
				}
			}
			if (secondQuestion == true) 
			{
				GUILayout.Label(questions[1]);
				if(GUILayout.Button(answers[1]))
				{
					secondQuestion=false;
					thirdQuestion = true;
				}
			}
			if (thirdQuestion == true) 
			{
				GUILayout.Label(questions[2]);
				if(GUILayout.Button(answers[2]))
				{
					thirdQuestion = false;
					forthQuestion = true;
				}
			}
			if (forthQuestion == true) 
			{
				GUILayout.Label(questions[3]);
				if(GUILayout.Button(answers[3]))
				{
					Application.LoadLevel ("cap0_2");
				}
			}
			
			
			
		}
		GUILayout.EndArea ();
		
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
