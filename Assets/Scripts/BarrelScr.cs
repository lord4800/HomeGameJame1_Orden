 using UnityEngine;
using System.Collections;

public class BarrelScr : MonoBehaviour {
	public float max_Water = 100f;
	public float cur_Water = 100f;
	public float thrust;
	public bool PoolOver = true;
	public GameObject waterBar;
	public GameObject connectObj;
	GameObject[] poolObjects;

	// Use this for initialization
	void Start () {
		cur_Water = max_Water;
		//InvokeRepeating("decreasewater",1f,1f);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GameObject.Find("SwitchWater").GetComponent<SwitchScr>().IsOn)
		{
			decreasewater();
			if(PoolOver)
			{
				poolObjects = GameObject.FindGameObjectsWithTag("Player");
				foreach (GameObject go in poolObjects)
				{
					Debug.Log("sss");
					go.GetComponent<Rigidbody2D>().AddForce(-transform.up*thrust);
				}

				poolObjects = GameObject.FindGameObjectsWithTag("PoolObject");
				foreach (GameObject go in poolObjects)
				{
					go.GetComponent<Rigidbody2D>().AddForce(-transform.up*thrust);
				}
			}
		}
		if (GameObject.Find("SwitchWater").GetComponent<SwitchScr>().IsOn)increasewater();
	}

	void decreasewater()
	{
		cur_Water -= 2f;
		float calc_water = cur_Water/max_Water;
		if (cur_Water < 0) 
		{
			cur_Water = 0;
			PoolOver = false;
		}
		SetWaterBar(calc_water);

	}
	void increasewater()
	{
		cur_Water += 2f;
		float calc_water = cur_Water/max_Water;
		if (cur_Water > 100) cur_Water = 100;
		SetWaterBar(calc_water);
		//connectObj.GetComponent<>();
	}

	public void SetWaterBar (float myWater)
	{
		waterBar.transform.localScale = new Vector3(waterBar.transform.localScale.x,myWater,waterBar.transform.localScale.z);
	}
}
