using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chain : MonoBehaviour {
	[FMODUnity.EventRef]
	[SerializeField]
	string chainEvent;
	FMOD.Studio.EventInstance chainEventInstance = null;
	const float period = 3.0f;
	float timer = period;
	const float maxPitch = 5.0f;

	[SerializeField] MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		chainEventInstance = FMODUnity.RuntimeManager.CreateInstance(chainEvent);
		chainEventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
		chainEventInstance.start();

	}

	void OnDestroy()
	{
		if (chainEventInstance != null)
		{
			chainEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			chainEventInstance.release();
			chainEventInstance = null;
		}
	}

	// Update is called once per frame
	void Update () {
		if (chainEventInstance != null)
		{
			if (timer > 0.0f)
			{
				chainEventInstance.setVolume(timer / period);
				chainEventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
				chainEventInstance.setPitch(maxPitch*(timer / period));
				timer -= Time.deltaTime;
				if(timer < 2.0f)
				{
					musicManager.ChangeScene();
					SceneManager.LoadScene("test2");
				}
			}
			else
			{
				chainEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
				chainEventInstance.release();
				chainEventInstance = null;
			}
		}

	}
}
