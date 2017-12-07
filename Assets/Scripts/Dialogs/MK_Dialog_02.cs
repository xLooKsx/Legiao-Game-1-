using UnityEngine;
using System.Collections;

public class MK_Dialog_02 : MonoBehaviour {
	public string[] questions;
	public string[] answers;
	bool displayDialog = false;
	public Vector3 dialogBox;
	public float dialogWidth;
	public float dialogtHeigth;
	
	public GUIText text1;
	public GUIText text2;
	public GUIText text3;
	
	
	public bool fistQuestion;
	public bool secondQuestion;

	private BauBehaviour bau;
	private PlayerBehaviour player;
	
	// Use this for initialization
	void Start () 
	{
		text1.enabled = false;
		text2.enabled = false;
		text3.enabled = false;
		fistQuestion = true;
		secondQuestion = false;
		bau = FindObjectOfType (typeof(BauBehaviour)) as BauBehaviour;
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
					text1.enabled=true;
					text2.enabled=true;
					text3.enabled = true;
					fistQuestion = false;
					secondQuestion = true;
					displayDialog = false;
					bau.visivel = true;
					
				}		
			}
			if (secondQuestion == true) 
			{
				GUILayout.Label(questions[1]);
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
