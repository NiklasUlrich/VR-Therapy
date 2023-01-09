using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Material))]
public class AudioSyncColor : AudioSyncer
{

	private IEnumerator MoveToColor(Color _target)
	{
		Color _curr = material.color;
		Color _initial = _curr;
		float _timer = 0;

		while (_curr != _target)
		{
			_curr = Color.Lerp(_initial, _target, audioValue);
			_timer += Time.deltaTime;

			material.color = _curr;

			yield return null;
		}
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		//if (spike) return;

		material.color = Color.Lerp(restColor, beatColor, audioValue * 30/*restSmoothTime * Time.deltaTime*/);
	}

	public override void Spike()
	{
		/*base.Spike();

		Color _c = RandomColor();

		StopCoroutine("MoveToColor");
		StartCoroutine("MoveToColor", _c);*/
	}

	private void Start()
	{
		material = GetComponent<Renderer>().material;
	}

	public Color beatColor;
	public Color restColor;

	private Material material;

	private int m_randomIndx;
}