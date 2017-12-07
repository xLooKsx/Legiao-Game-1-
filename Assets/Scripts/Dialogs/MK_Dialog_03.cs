using UnityEngine;
using System.Collections;

public class MK_Dialog_03 : MonoBehaviour {
	public string[] questions;
	public string[] answers;
	bool displayDialog = false;
	public Vector3 dialogBox;
	public float dialogWidth;
	public float dialogtHeigth;
	
	public bool fistQuestion;
	public bool secondQuestion;
	
	private Bau2Behaviour bau;
	
	
	// Use this for initialization
	void Start () 
	{
		fistQuestion = true;
		secondQuestion = false;
		bau = FindObjectOfType(typeof(Bau2Behaviour))as Bau2Behaviour;
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
					bau.visivel = true;
					
				}		
			}
			if (secondQuestion == true) 
			{
				GUILayout.Label(questions[1]);

				if(GUILayout.Button(answers[0]))
				{
					Application.LoadLevel("cap0_3");
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
