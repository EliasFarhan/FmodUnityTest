using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	[FMODUnity.EventRef]
	[SerializeField]
	string itemEvent;
	// Use this for initialization
	void Start ()
	{
		FMODUnity.RuntimeManager.PlayOneShot(itemEvent);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
