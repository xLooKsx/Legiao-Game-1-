using UnityEngine;
using System.Collections;

public class PlayerStatsController : MonoBehaviour {

	public static PlayerStatsController instance;

	public float xpToUp = 100;

	private float xpNextLevel;

	public static int maxHp;
	public int hp;
	public static int maxMp;
	public int mp;
	public int atkBase;
	public int MatkBase;
	public static int mpPotion= 0;

	

	// Use this for initialization
	void Start () {

		instance = this;
		DontDestroyOnLoad(gameObject);
		maxHp = 100;
		AddHp (maxHp);
		hp = maxHp;
		maxMp = 100;
		AddMp (maxMp);
		mp = maxMp;
		atkBase = 5;
		MatkBase = 8;
		Application.LoadLevel("cap0_1");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			PlayerPrefs.DeleteAll ();
		}

		if (Input.GetKeyDown (KeyCode.M)) 
		{
			if (mpPotion > 0) 
			{
				if (GetCurrentMp () == 0) 
				{
					AddMp (GetCurrentMp()+100);
					mpPotion--;
				}


			}
		}

	}

	// adicionar Xp
	public void AddXp(float xpAdd)
	{
		float newXp = GetCurrentXp() + xpAdd;
		while(newXp >= GetNextXp ()) 
		{
			newXp -= GetNextXp();
			AddLevel ();
			maxHp+=10;
			maxMp+=10;
			AddMp(maxMp);
			AddHp(maxMp);

		}
		PlayerPrefs.SetFloat("currentXp", newXp);
	}

	// pegar o Xp atual
	public static float GetCurrentXp()
	{
		return PlayerPrefs.GetFloat("currentXp");
	}

	// pegar o level atual
	public static int GetCurrentLevel()
	{
		return PlayerPrefs.GetInt("currentLevel");
	}

	// adicionar level
	public static void AddLevel()
	{
		int newLevel = GetCurrentLevel()+1;
		PlayerPrefs.SetInt("currentLevel", newLevel);
	}

	public static float GetNextXp()
	{
		return PlayerStatsController.instance.xpToUp * (GetCurrentLevel()+1);
	}

	public static int GetCurrentHp()
	{
		return PlayerPrefs.GetInt("currentHp");
	}
	public static void AddHp(int php)
	{
		PlayerPrefs.SetInt("currentHp", php);
	}


	public static int GetCurrentMp()
	{
		return PlayerPrefs.GetInt("currentMp");
	}
	public static void AddMp(int pmp)
	{
		PlayerPrefs.SetInt("currentMp", pmp);
	}
	

	//GUI
	void OnGUI()
	{
		GUI.Label(new Rect(0,0,200,50),"current  Hp: "+ GetCurrentHp() + "/ " + maxHp);
		GUI.Label(new Rect(0,15,200,50),"current  Mp: "+ GetCurrentMp() + "/ " + maxMp);
		GUI.Label(new Rect(0,30,200,50),"current  Xp: "+ GetCurrentXp());
		GUI.Label(new Rect(0,45,200,50),"current Level: "+ GetCurrentLevel());
		GUI.Label(new Rect(0,60,200,50),"current NextXp: "+ GetNextXp());
		GUI.Label(new Rect(0,90,200,50),"Poçoes de MP: "+ mpPotion);
	}

}
