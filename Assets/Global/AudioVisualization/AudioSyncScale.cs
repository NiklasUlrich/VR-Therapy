using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{
	protected override void OnUpdate()
	{
		base.Update();

		transform.localScale = Vector3.Lerp(restScale, beatScale, audioValue * sensitivity);
	}

	public Vector3 beatScale;
	public Vector3 restScale;
}
