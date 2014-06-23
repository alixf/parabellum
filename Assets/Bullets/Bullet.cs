using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed;
	public float damage;

	void Start ()
	{
	}
	
	void Update ()
	{
		transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("void"))
			Destroy(gameObject);

		if(other.CompareTag("enemy"))
		{
			Enemy enemy = other.GetComponent<Enemy>();
			enemy.hit(damage);
			Destroy(gameObject);
		}
	}
}
