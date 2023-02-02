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
	public float restSmoothTime;
	public float lerpFactor;

	protected float audioValue = 0;

	private bool frequencyValuesAcceptable = true;

	private float previousAudioValue;
	private float timer = 0;

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
	public virtual void OnUpdate()
	{
		if (!frequencyValuesAcceptable) return;
		// update audio value
		previousAudioValue = audioValue;
		previousAudioValue = Mathf.Lerp(previousAudioValue, 0, timer / restSmoothTime);

		float spectrumValue = 0;
		float[] audioSpectrum = AudioSpectrum.audioSpectrum;

		if (audioSpectrum != null && audioSpectrum.Length >= 0)
        {
			for(int i = lowestFrequency; i <= highestFrequency; i++)
            {
				spectrumValue += audioSpectrum[i];
            }

			spectrumValue /= highestFrequency - lowestFrequency + 1;

			//Debug.Log("spectrum value: " + spectrumValue);
		}

		if (spectrumValue >= bias && spectrumValue > previousAudioValue)
        {
			audioValue = Mathf.Lerp(previousAudioValue, spectrumValue, lerpFactor);
			timer = 0;
		}
        else
        {
			audioValue = previousAudioValue;
		}
		timer += Time.deltaTime;
	}

	private void Update()
	{
		OnUpdate();
	}


}