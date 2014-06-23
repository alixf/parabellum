using UnityEngine;
using System.Collections;

public class Crust : MonoBehaviour
{
	public Transform groundParticles;

	void Start ()
	{
	}
	
	void Update ()
	{	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("bullet"))
		{
			Transform gp = Instantiate(groundParticles) as Transform;
			gp.parent = transform;
			gp.transform.localPosition = new Vector3(other.transform.position.x, 0f, 0.5f);
			Destroy(gp.gameObject, 1);
		}
	}
}
