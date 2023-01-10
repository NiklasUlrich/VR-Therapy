using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mini "engine" for analyzing spectrum data
/// Feel free to get fancy in here for more accurate visualizations!
/// </summary>
public class AudioSpectrum : MonoBehaviour
{

    private void Update()
    {
        // get the data
        AudioListener.GetSpectrumData(audioSpectrum, 0, FFTWindow.Hamming);

        // assign spectrum value
        // this "engine" focuses on the simplicity of other classes only..
        // ..needing to retrieve one value (spectrumValue)
        if (audioSpectrum != null && audioSpectrum.Length > 0)
        {
            spectrumValue = audioSpectrum[0];
            //Debug.Log("audio value: " + spectrumValue);
        }
    }

    private void Start()
    {
        /// initialize buffer
        audioSpectrum = new float[128];
    }

    // This value served to AudioSyncer for beat extraction
    public static float spectrumValue { get; private set; }

    // Unity fills this up for us
    public static float[] audioSpectrum { get; private set; }

}