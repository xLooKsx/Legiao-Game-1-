using UnityEngine;
using System.Collections;

public class FadeOutBehaviour : MonoBehaviour {

	public Camera preto;
	public Camera cinzaEscurao;
	public Camera cinzaEscuro;
	public Camera cinzaClaro;

	public bool bCinzaEscuro;
	public bool bCinzaEscurao;
	public bool bpreto;

	private float timer = 0;
	public float time = 2f;

	// Use this for initialization
	void Start () 
	{
		disable ();
		cinzaClaro.enabled = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cinzaClaro.enabled)
		{
			timer +=Time.deltaTime;
			if (timer >= time) 
			{
				timer = 0;
				disable ();
				cinzaEscuro.enabled=true;
				
			}
		}
		if (cinzaEscuro.enabled)
		{
			timer +=Time.deltaTime;
			if (timer >= time) 
			{
				timer = 0;
				disable ();
				cinzaEscurao.enabled=true;
				
			}
		}
		if (cinzaEscurao.enabled)
		{
			timer +=Time.deltaTime;
			if (timer >= time) 
			{
				timer = 0;
				disable ();
				preto.enabled=true;
				
			}
		}
		if (preto.enabled)
		{
			timer +=Time.deltaTime;
			if (timer >= time) 
			{
				timer = 0;
				disable ();
				preto.enabled=true;
				
			}
		}


	}
	void disable()
	{
		preto.enabled = false;
		cinzaEscurao.enabled = false;
		cinzaEscuro.enabled = false;
		cinzaClaro.enabled = false;
	}
}
