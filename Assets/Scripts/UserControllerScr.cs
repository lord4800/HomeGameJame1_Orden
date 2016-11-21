using UnityEngine;
using System.Collections;

public class UserControllerScr : MonoBehaviour {
	public GameObject Head;
	public GameObject Tail;
	Vector3 tempPos1;
	Vector3 tempPos2;
	public Vector2 speed = new Vector2(10,10);
	Animator animatorFire;
	Animator animatorWater;
	bool magic = false;
	Vector2 movement;


	// Use this for initialization
	void Start () {
		Physics2D.gravity = new Vector2(0f, 0F);
		animatorFire = Head.GetComponent<Animator>();
		animatorWater = Tail.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(speed.x * inputX,speed.y * inputY);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//StartCoroutine(swapHeadTail());
			swapHeadTail();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			//StartCoroutine(swapHeadTail());
			changePlayer();
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
		{
			Head.GetComponent<Animator>().SetInteger("State",1);
			Tail.GetComponent<Animator>().SetInteger("State",1);
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
			Head.GetComponent<Animator>().SetInteger("State",0);
			Tail.GetComponent<Animator>().SetInteger("State",0);
		}



		if (Input.GetKeyDown(KeyCode.Y))
		{
			magic = true;
			Tail.GetComponent<Animator>().SetInteger("State",2);
			Head.GetComponent<Animator>().SetInteger("State",2);
		}
		if (Input.GetKeyUp(KeyCode.Y))
		{
			magic = false;
			Tail.GetComponent<Animator>().SetInteger("State",0);
			Head.GetComponent<Animator>().SetInteger("State",0);
		}

	}
	void changePlayer()
	{
		GameObject[] gm = GameObject.FindGameObjectsWithTag(GameObject.FindGameObjectWithTag("GameController").GetComponent<UserControllerScr>().Head.GetComponent<PlayerClass>().FindTag);
		{
			foreach(GameObject _gm in gm)
			{

				Renderer rend = _gm.GetComponent<Renderer>();
				rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,1);
			}
		}
		GameObject temp;
		temp = Head;
		Head = Tail;
		Tail = temp;
		GameObject cam ;
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		//cam.GetComponent<CameraScr>().player = Head;
		cam.GetComponent<CameraScr>().target = Head;

	}

	void swapHeadTail()
	{
		tempPos1 = Head.transform.position;
		tempPos2 = Tail.transform.position;
		//animatorFire.SetInteger("State",1);
		//animatorWater.SetInteger("State",1);
		StartCoroutine (Swap (10));
		StopCoroutine (Swap(10));
		//animatorFire.SetInteger("State",0);
		//animatorWater.SetInteger("State",0);
	}
	IEnumerator Swap(float time)
	{
		//float i = 0;
		for (float i = 0; i < time; i +=0.1f)
		//while (i<1) 
		{
			i+=Time.deltaTime/time;
			Tail.transform.position=Vector3.Lerp(Tail.transform.position,tempPos1,i);
			Head.transform.position=Vector3.Lerp(Head.transform.position,tempPos2,i);
			yield return null;
		}
	}
	void FixedUpdate()
	{
		Head.GetComponent<Rigidbody2D>().velocity = movement;
		Tail.GetComponent<Rigidbody2D>().velocity = movement;
	}
	void OnTriggerEnter(Collider myTrigger)
	{
		if (myTrigger.gameObject.tag == "Switch")
		{
			if (Head.GetComponent<PlayerClass>().FindTag == "GasPipe" && myTrigger.gameObject.name == "SwitchGas" && magic)
			{
				myTrigger.gameObject.GetComponent<SwitchScr>().ChangeSprite();
			}
			if (Head.GetComponent<PlayerClass>().FindTag == "WaterPipe" && myTrigger.gameObject.name == "SwitchWater" && magic)
			{
				myTrigger.gameObject.GetComponent<SwitchScr>().ChangeSprite();
			}
		}
	}

}
