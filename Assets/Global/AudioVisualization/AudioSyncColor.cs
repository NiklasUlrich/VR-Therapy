using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Material))]
public class AudioSyncColor : AudioSyncer
{

	public override void OnUpdate()
	{
		base.OnUpdate();

		//if (spike) return;

		material.color = Color.Lerp(restColor, beatColor, audioValue * sensitivity);
	}

	private void Start()
	{
		material = GetComponent<Renderer>().material;
	}

	public Color beatColor;
	public Color restColor;

	private Material material;
}