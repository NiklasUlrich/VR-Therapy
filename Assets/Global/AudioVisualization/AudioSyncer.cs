using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class responsible for extracting beats from..
/// ..spectrum value given by AudioSpectrum.cs
/// </summary>
public class AudioSyncer : MonoBehaviour
{

	/// <summary>
	/// Inherit this to cause some behavior on each sound spike
	/// </summary>
	public virtual void Spike()
    {
		spike = true;
    }

	/// <summary>
	/// Inherit this to do whatever you want in Unity's update function
	/// Typically, this is used to arrive at some rest state..
	/// ..defined by the child class
	/// </summary>
	public virtual void OnUpdate()
	{
		Debug.Log("Spike is " + spike);
		// update audio value
		m_previousAudioValue = audioValue;

		if(AudioSpectrum.spectrumValue >= bias)
        {
			audioValue = AudioSpectrum.spectrumValue;
			
			if(audioValue >= m_previousAudioValue)
            {
				Spike();
				return;
            }
		}
		spike = false;
	}

	private void Update()
	{
		OnUpdate();
	}

	public float bias;
	public float timeStep;
	public float restSmoothTime;

	protected float audioValue = 0;
	protected bool spike = false;

	private float m_previousAudioValue;
	private float m_timer;
}