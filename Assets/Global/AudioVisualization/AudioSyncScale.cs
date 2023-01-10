using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{
	public override void OnUpdate()
	{
		base.OnUpdate();

		transform.localScale = Vector3.Lerp(restScale, beatScale, audioValue * sensitivity);
	}

	public Vector3 beatScale;
	public Vector3 restScale;
}
