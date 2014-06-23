using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour
{
	public float scrollRate;
	void Update ()
	{
		renderer.material.SetTextureOffset("_MainTex", new Vector2(Time.time * scrollRate, 0f));
	}
}
