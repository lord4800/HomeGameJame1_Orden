using UnityEngine;
using System.Collections;

public class LightScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDrawGizmos()
	{
		/*
		Gizmos.DrawIcon(transform.position,"Light Gizmo.tiff",true);
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 2);
		*/
		UnityEditor.Handles.color = Color.yellow;
		UnityEditor.Handles.DrawWireDisc(transform.position,new Vector3(0,0,1),5);
	}
}
