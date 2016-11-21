using UnityEngine;
using System.Collections;

public class LiftScript : MonoBehaviour 
{
	float time = 0f;
	float speed = 4f;
	bool isIncrement = false;
	public bool isFlashing = false;
	// Use this for initialization
	void setFlashing()
	{
		isFlashing = true; 
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		

		GameObject[] gm = GameObject.FindGameObjectsWithTag(GameObject.FindGameObjectWithTag("GameController").GetComponent<UserControllerScr>().Head.GetComponent<PlayerClass>().FindTag);
		if (!isIncrement)time += Time.deltaTime*speed;
		else time -= Time.deltaTime*speed;
		if (time < 5f && time > 4.8f)
		{
			isIncrement = true;
		}
		if (time <= 2f)
		{
			isIncrement = false;
		}
		if(isFlashing)
		{
			foreach(GameObject _gm in gm)
			{
				
				Renderer rend = _gm.GetComponent<Renderer>();
			rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,time/5);
			}
		}
	}
}
