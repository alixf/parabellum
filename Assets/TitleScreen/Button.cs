using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public int levelToLoad;

	private SpriteRenderer r;

	void Start ()
	{
		r = GetComponent<SpriteRenderer>();	
		Color color = r.color;
		color.a = 0.33f;
		r.color = color;
	}
	
	void Update ()
	{
			Color color = r.color;
			BoxCollider2D box = GetComponent<BoxCollider2D>();
			if(box.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
			{
				color.a = Mathf.Clamp(color.a + 0.05f, 0.33f, 1f);
				if(Input.GetMouseButton(0))
				{
					if(levelToLoad == -1)
						Application.Quit();
					else
						Application.LoadLevel(levelToLoad);
				}	
			}
			else
				color.a = Mathf.Clamp(color.a - 0.05f, 0.33f, 1f);
			r.color = color;
	}
}
