using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Material))]
public class AudioSyncColor : AudioSyncer
{

	protected override void OnUpdate()
	{
		base.OnUpdate();


		material.color = Color.Lerp(restColor, beatColor, audioValue * sensitivity);
	}

	protected override void Start()
	{
		base.Start();
		material = GetComponent<Renderer>().material;
	}

	public Color beatColor;
	public Color restColor;

	private Material material;
}