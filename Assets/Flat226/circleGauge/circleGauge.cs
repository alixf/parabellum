using UnityEngine;
using System.Collections;

public class circleGauge : MonoBehaviour
{
	public float progress;
	private float _progress;

	void Awake()
	{
		_progress = progress;
		renderer.material.mainTextureOffset = new Vector2(Mathf.Lerp(0.5f, 0, progress), renderer.material.mainTextureOffset.y);
	}
	
	void Update()
	{
		if(progress != _progress)
		{
			_progress = progress;
			renderer.material.mainTextureOffset = new Vector2(Mathf.Lerp(0.5f, 0, progress), renderer.material.mainTextureOffset.y);
		}
	}
}
