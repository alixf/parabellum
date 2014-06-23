using UnityEngine;
using System.Collections;

public class CutScene : MonoBehaviour
{
	public Transform[] layers;
	public float frameTime;
	public AnimationCurve frameOpacity;
	public int levelToLoad;

	private float clock;

	void Start ()
	{
		foreach(Transform layer in layers)
		{
			foreach(Transform obj in layer)
			{
				Color color = obj.GetComponent<SpriteRenderer>().color;
				color.a = 0;
				obj.GetComponent<SpriteRenderer>().color = color;
			}
		}
	}
	
	void Update ()
	{
		clock += Time.deltaTime;

		if(Input.GetKeyDown("space"))
		{
			clock += frameTime - (clock % frameTime);
		}

		for(int i = 0; i < layers.Length; ++i)
		{
			Transform layer = layers[i];
		
			float realTime = clock - frameTime * i;
			float opacity = Mathf.Clamp(frameOpacity.Evaluate(realTime / frameTime), 0f, 1f);
			foreach(Transform obj in layer)
			{
				Color color = obj.GetComponent<SpriteRenderer>().color;
				color.a = opacity;
				obj.GetComponent<SpriteRenderer>().color = color;
			}
		}

		if(clock > frameTime*layers.Length)
			Application.LoadLevel(levelToLoad);
	}
}
