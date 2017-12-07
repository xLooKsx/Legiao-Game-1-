using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {

	public Vector3 buttonStart;
	public Vector3 buttonHelp;
	public Vector3 buttonQuit;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{

		if (GUI.Button (new Rect (buttonStart.x, buttonStart.y, 80, 30), "")) 
		{
			Application.LoadLevel("Loader");
		}

		if (GUI.Button (new Rect (buttonHelp.x, buttonHelp.y, 80, 30), "")) 
		{
			Application.LoadLevel("Help");
		}

		if (GUI.Button (new Rect (buttonQuit.x, buttonQuit.y, 80, 30), "")) 
		{
			Application.Quit();
		}



	}
}
