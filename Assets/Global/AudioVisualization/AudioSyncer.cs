using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class responsible for extracting beats from..
/// ..spectrum value given by AudioSpectrum.cs
/// </summary>
public abstract class AudioSyncer : MonoBehaviour
{
	[Tooltip("Lowest Frequency that will be read. Has to be 0 - 127")]
	public int lowestFrequency;

	[Tooltip("Highest Frequency that will be read. Has to be 0 - 127")]
	public int highestFrequency;

	public float sensitivity;
	public float bias;

	public float smoothTime;

	public bool alsoSmoothRise;

	protected float audioValue = 0;

	private bool frequencyValuesAcceptable = true;

	private float spectrumValueSum = 0;
	private int spectrumValueCount = 0;
	private float smoothLerpTarget = 0;
	private float smoothLerpStart = 0;

	private float restTimer = 0;
	private float intervalTimer = 0;

	protected virtual void Start()
    {
        if (!(lowestFrequency <= highestFrequency))
        {
			Debug.LogError("Error in Audiosyncer object. Lowest Frequency needs to be equal to or lower than Highest Frequency.");
			frequencyValuesAcceptable = false;
			return;
        }
		if(lowestFrequency < 0)
        {
			Debug.LogError("Error in Audiosyncer object. Lowest Frequency needs to be positive.");
			frequencyValuesAcceptable = false;
		}
		if (highestFrequency > 127)
		{
			Debug.LogError("Error in Audiosyncer object. Highest Frequency needs to be lower than 128.");
			frequencyValuesAcceptable = false;
		}
	}

	/// <summary>
	/// Inherit this to do whatever you want in Unity's update function
	/// Typically, this is used to arrive at some rest state..
	/// ..defined by the child class
	/// </summary>
	private void OnUpdate()
	{
		if (!frequencyValuesAcceptable) return;

		float spectrumValue = 0;
		float[] audioSpectrum = AudioSpectrum.audioSpectrum;

		//calculate average audiovalue from selected frequencies
		if (audioSpectrum != null && audioSpectrum.Length >= 0)
        {
			for(int i = lowestFrequency; i <= highestFrequency; i++)
            {
				spectrumValue += audioSpectrum[i];
            }

			spectrumValue /= highestFrequency - lowestFrequency + 1;

			//Debug.Log("spectrum value: " + spectrumValue);
		}

        if (!alsoSmoothRise)
        {
			immediateSyncing(spectrumValue);
			return;
        }
		smoothSyncing(spectrumValue);
	}

	private void smoothSyncing(float spectrumValue)
    {
		if(intervalTimer >= smoothTime)
        {
			smoothLerpStart = audioValue;
			smoothLerpTarget = spectrumValueSum / spectrumValueCount;
			spectrumValueCount = 0;
			spectrumValueSum = 0;
			intervalTimer = 0;
		}
        else
        {
			spectrumValueSum += spectrumValue;
			spectrumValueCount++;
        }
		audioValue = Mathf.Lerp(smoothLerpStart, smoothLerpTarget, intervalTimer / smoothTime);
		intervalTimer += Time.deltaTime;
	}

	private void immediateSyncing(float spectrumValue)
    {
		if (spectrumValue >= bias && spectrumValue > audioValue)
		{
			audioValue = spectrumValue;
			restTimer = 0;
		}
		else
		{
			audioValue = Mathf.Lerp(audioValue, 0, restTimer / smoothTime);
		}
		restTimer += Time.deltaTime;
	}

	protected virtual void Update()
	{
		OnUpdate();	
	}


}