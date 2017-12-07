using UnityEngine;
using System.Collections;

public class MK_Dialog_04 : MonoBehaviour {
	public string[] questions;
	public string[] answers;
	bool displayDialog = false;
	public Vector3 dialogBox;
	public float dialogWidth;
	public float dialogtHeigth;
	
	public bool fistQuestion;
	public bool secondQuestion;
	public bool thirdQuestion;
	public bool fourthQuestion;
	public bool fivethQuestion;

	public Transform boneco;

	public bool golemDie;

	public Transform powerPrefab;

	
	
	// Use this for initialization
	void Start () 
	{
		fistQuestion = true;
		secondQuestion = false;
		thirdQuestion = false;
		fourthQuestion = false;
		fivethQuestion = false;
		golemDie = false;
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
					fistQuestion = false;
					displayDialog = false;
					GameObject projectilMelle = Instantiate(boneco.gameObject, (transform.position + new Vector3(10f,0,-1)), new Quaternion(0,0,0,0)) as GameObject;
					
				}		
			}
			if (golemDie) 
			{
				GUILayout.Label(questions[1]);
				if(GUILayout.Button(answers[1]))
				{
					golemDie = false;
					PlayerStatsController.AddMp (0);
					secondQuestion = true;
				}		
			}
			if (secondQuestion)
			{
				GUILayout.Label(questions[2]);
				if(GUILayout.Button(answers[1]))
				{
					secondQuestion=false;
					thirdQuestion = true;
					displayDialog= false;

				}	

			}
			if (thirdQuestion)
			{
				GUILayout.Label(questions[3]);
				if(GUILayout.Button(answers[2]))
				{
					thirdQuestion = false;
					PlayerStatsController.AddHp (PlayerStatsController.GetCurrentHp ()-20);
					fourthQuestion = true;
				}	
			}
			if (fourthQuestion)
			{
				GUILayout.Label(questions[4]);
				if(GUILayout.Button(answers[2]))
				{
					fourthQuestion = false;
					fivethQuestion = true;
				}	
			}
			if (fivethQuestion)
			{
				GUILayout.Label(questions[5]);
				if(GUILayout.Button(answers[2]))
				{
					fivethQuestion = false;
					Application.LoadLevel("TimeSkip");
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
