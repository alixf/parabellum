using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
	public Transform b1;
	public Transform b2;
	public BoxCollider2D nextLevel;
	public BoxCollider2D up0;
	public BoxCollider2D up1;
	public BoxCollider2D up2;
	public BoxCollider2D up3;
	public BoxCollider2D up4;
	public BoxCollider2D up5;
	public BoxCollider2D weapon0;
	public BoxCollider2D weapon1;
	public BoxCollider2D weapon2;
	public BoxCollider2D weapon3;
	public BoxCollider2D weapon4;
	public BoxCollider2D weapon5;
	public Transform[][] points;
	public Transform rp;

	public int levelToLoad;

	public int weapon1Index = 0;
	public int weapon2Index = 1;
	public int availableRP = 3;
	public int[] levels = new int[6];
	private Transform[,] rps;
	private Transform[] rpa;

	void Start()
	{
		weapon1Index = DataManager.Instance.weapon1Index;
		weapon2Index = DataManager.Instance.weapon2Index;
		availableRP = DataManager.Instance.availableRP;
		levels = (int[])DataManager.Instance.weaponLevels.Clone();

		levelToLoad = DataManager.Instance.nextLevel + 2;

		changePrimaryWeapon(weapon1Index);
		changeSecondaryWeapon(weapon2Index);
		rps = new Transform[6, 12];
		rpa = new Transform[availableRP];

		for(int i = 0; i < 6; ++i)
		{
			for(int j = 0; j < 12; ++j)
			{
				rps[i,j] = Instantiate(rp) as Transform;
				rps[i,j].parent = this.transform;
				rps[i,j].localPosition = new Vector3(-1.75f + j * 0.6f, 2.85f + i * -0.6f, 0f);
			}
		}
		for(int j = 0; j < availableRP; ++j)
		{
			rpa[j] = Instantiate(rp) as Transform;
			rpa[j].parent = this.transform;
			rpa[j].localPosition = new Vector3(3.3f + j * 0.6f, 3.72f, 0f);
		}

		updateGrid();
	}
	
	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			if(weapon0.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changePrimaryWeapon(0);
			if(weapon1.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changePrimaryWeapon(1);
			if(weapon2.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changePrimaryWeapon(2);
			if(weapon3.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changePrimaryWeapon(3);
			if(weapon4.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changePrimaryWeapon(4);
			if(weapon5.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changePrimaryWeapon(5);
		}

		if(Input.GetMouseButtonDown(0))
		{
			if(up0.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				upgradeWeapon(0);
			if(up1.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				upgradeWeapon(1);
			if(up2.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				upgradeWeapon(2);
			if(up3.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				upgradeWeapon(3);
			if(up4.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				upgradeWeapon(4);
			if(up5.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				upgradeWeapon(5);

			if(nextLevel.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
			{
				DataManager.Instance.weapon1Index = weapon1Index;
				DataManager.Instance.weapon2Index = weapon2Index;
				DataManager.Instance.availableRP = availableRP;
				DataManager.Instance.weaponLevels = (int[])levels.Clone();

				Application.LoadLevel(levelToLoad);
			}
		}
		if(Input.GetMouseButton(1))
		{
			if(weapon0.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changeSecondaryWeapon(0);
			if(weapon1.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changeSecondaryWeapon(1);
			if(weapon2.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changeSecondaryWeapon(2);
			if(weapon3.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changeSecondaryWeapon(3);
			if(weapon4.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changeSecondaryWeapon(4);
			if(weapon5.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))))
				changeSecondaryWeapon(5);
		}
	}

	public void changePrimaryWeapon(int weaponIndex)
	{
		int tmp = weapon1Index;
		weapon1Index = weaponIndex;
		if(weapon2Index == weaponIndex)
			changeSecondaryWeapon(tmp);

		b1.localPosition = new Vector3(-7.46f, 2.85f + weaponIndex * (-0.60f), 0f);
	}

	public void changeSecondaryWeapon(int weaponIndex)
	{
		int tmp = weapon2Index;
		weapon2Index = weaponIndex;
		if(weapon1Index == weaponIndex)
			changePrimaryWeapon(tmp);

		b2.localPosition = new Vector3(-7.46f, 2.85f + weaponIndex * (-0.60f), 0f);
	}

	public void upgradeWeapon(int weaponIndex)
	{
		if(availableRP > 0)
		{
			availableRP--;
			levels[weaponIndex]++;
			updateGrid();
		}
	}

	public void updateGrid()
	{
		for(int i = 0; i < 6; ++i)
		{
			for(int j = 0; j < 12; ++j)
			{
				Color c = rps[i,j].GetComponent<SpriteRenderer>().color;
				c.a = (levels[i] > j) ? 1f : 0.25f;
				rps[i,j].GetComponent<SpriteRenderer>().color = c;
			}
		}
		for(int j = 0; j < rpa.Length; ++j)
		{
			Color c = rpa[j].GetComponent<SpriteRenderer>().color;
			c.a = (j >= availableRP) ? 0f : 1f;
			rpa[j].GetComponent<SpriteRenderer>().color = c;
		}
	}
}
