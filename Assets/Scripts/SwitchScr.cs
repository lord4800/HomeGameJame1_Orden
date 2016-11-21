using UnityEngine;
using System.Collections;

public class SwitchScr : MonoBehaviour {
	public bool IsOn = false;
	public Sprite SOn;
	public Sprite SOff;

	// Use this for initialization
	public void ChangeSprite()
	{
		IsOn = !IsOn;
		if (IsOn)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = SOn;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = SOff;
		}
	}
	
	// Update is called once per frame

}
