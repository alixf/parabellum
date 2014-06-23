using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public Transform bulletToSpawn;
	public float shootingRate;
	public Vector2[] shootingLocations;
	public float shootingPower;

	private float clock = 0f;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}

	public void Shoot()
	{
		clock += Time.deltaTime;
		if(clock > 1 / shootingRate)
		{
			Vector2 mouseCoord = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

			foreach(Vector2 shootingLocation in shootingLocations)
			{
				Vector2 position = new Vector2(transform.position.x, transform.position.y) + shootingLocation;
				Quaternion angle = Quaternion.AngleAxis(Mathf.Atan2(mouseCoord.y - position.y, mouseCoord.x - position.x) * Mathf.Rad2Deg, Vector3.forward);
				Transform bullet = Instantiate(bulletToSpawn, position, angle) as Transform;
				bullet.rigidbody2D.AddForce(bullet.right * shootingPower);
			}

			clock = 0f;
		}
	}
}
