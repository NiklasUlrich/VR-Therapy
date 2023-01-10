using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class responsible for extracting beats from..
/// ..spectrum value given by AudioSpectrum.cs
/// </summary>
public abstract class AudioSyncer : MonoBehaviour
{

	/// <summary>
	/// Inherit this to do whatever you want in Unity's update function
	/// Typically, this is used to arrive at some rest state..
	/// ..defined by the child class
	/// </summary>
	public virtual void OnUpdate()
	{
		// update audio value
		previousAudioValue = audioValue;
		previousAudioValue = Mathf.Lerp(previousAudioValue, 0, timer / restSmoothTime);

		float spectrumValue = 0;
		if (AudioSpectrum.audioSpectrum != null && AudioSpectrum.audioSpectrum.Length >= 0 && AudioSpectrum.audioSpectrum.Length > frequency)
        {
			spectrumValue = AudioSpectrum.audioSpectrum[frequency];
			Debug.Log("spectrum value: " + spectrumValue);
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

    public int frequency;
	public float sensitivity;
	public float bias;
	public float restSmoothTime;
	public float lerpFactor;

	protected float audioValue = 0;

	private float previousAudioValue;
	private float timer = 0;
}