using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	[FMODUnity.EventRef]
	[SerializeField]
	string musicEvent;
	FMOD.Studio.EventInstance musicEventInstance = null;
	// Use this for initialization
	void Start ()

	{
		DontDestroyOnLoad(gameObject);
		musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
		musicEventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
		musicEventInstance.start();
	}
	public void ChangeScene()
	{ 
		if(musicEventInstance != null)
		{
			musicEventInstance.setParameterValue("Transition Niveau", 0.5f);
		}
	}
}
