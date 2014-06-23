using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	public float moveSpanMin;
	public float moveSpanMax;
	public float moveSpeed;

	public Weapon weapon1;
	public Weapon weapon2;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		// Move
		if(Input.GetKey("q"))
			transform.position -= new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
		if(Input.GetKey("d"))
			transform.position += new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
		if(transform.position.x < moveSpanMin)
			transform.position = new Vector3(moveSpanMin, transform.position.y, transform.position.z);
		if(transform.position.x > moveSpanMax)
			transform.position = new Vector3(moveSpanMax, transform.position.y, transform.position.z);

		// Shoot
		if(Input.GetMouseButton(0)) // LClick
			if(weapon1)
				weapon1.Shoot();
		if(Input.GetMouseButton(1)) // RClick
			if(weapon2)
				weapon2.Shoot();
	}
}
