using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	// Move
	public float spawnDelay;
	public Vector3 spawnLocation;
	public Vector3 velocity;
	public float sinWaveAmplitude;

	// Properties
	public float health;

	private float initialPositionY;
	private float clock;
	private bool spawned;
	private bool alive;

	private circleGauge healthGauge;
	private float maxHealth;

	void Awake ()
	{
		maxHealth = health;
		initialPositionY = transform.position.y;
		clock = 0f;
		spawned = false;
		alive = true;
	}

	void Start()
	{
		healthGauge = transform.Find("circleGauge").GetComponent<circleGauge>();
	}
	
	void Update ()
	{
		clock += Time.deltaTime;

		if(clock > spawnDelay && !spawned)
		{
			spawned = true;
			transform.position = spawnLocation;
			clock = 0f;
		}
		if(spawned && alive)
		{
			transform.position += velocity * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, initialPositionY + Mathf.Sin(clock) * sinWaveAmplitude, transform.position.z);
		}
		if(transform.position.x < -10)
		{
			Destroy(gameObject);
		}
	}

	public void hit(float damage)
	{
		health -= damage;
		healthGauge.progress = health / maxHealth;
		if(health <= 0f)
		{
			rigidbody2D.isKinematic = false;
			alive = false;
			collider2D.isTrigger = false;
			rigidbody2D.AddTorque(-25f);
			rigidbody2D.AddForce(new Vector2(100f, 100f));
			clock = 0f;
			StartCoroutine(disappear(2.5f));
			GameObject.Find("level").GetComponent<Level>().enemiesShot++;
		}
	}

	IEnumerator disappear(float duration)
	{
		while(clock <= duration && gameObject != null)
		{
			Color color = GetComponent<SpriteRenderer>().color;
			color.a = Mathf.Lerp(1f, 0f, clock / duration);
			GetComponent<SpriteRenderer>().color = color;
			yield return null;
		}
		Destroy(gameObject);
	}
}
