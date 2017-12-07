using UnityEngine;
using System.Collections;

public class BauBehaviour : MonoBehaviour {
	
	public string[] questions;
	public string[] answers;
	bool displayDialog = false;
	public Vector3 dialogBox;
	public float dialogWidth;
	public float dialogtHeigth;
	
	public bool fistQuestion;
	public bool secondQuestion;
	public bool thirdQuestion;
	
	public GUIText text1;
	public GUIText text2;
	public GUIText text3;

	public bool visivel= false;
	

	
	private PlayerBehaviour player;
	
	// Use this for initialization
	void Start () 
	{

		text1.enabled = false;
		text2.enabled = false;
		text3.enabled=false;
		
		fistQuestion = true;
		secondQuestion = false;
		thirdQuestion = false;

		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
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
						text1.enabled=false;
						text2.enabled=false;
						text3.enabled=false;
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
						PlayerStatsController.maxMp+=20;
						PlayerStatsController.AddMp (PlayerStatsController.GetCurrentMp ()+20);		
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
