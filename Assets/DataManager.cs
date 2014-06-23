using UnityEngine;
using System.Collections;

public class DataManager : Singleton<DataManager>
{
	public int[] weaponLevels;
	public int availableRP;
	public int weapon1Index;
	public int weapon2Index;
	public int nextLevel;

	public DataManager()
	{
		weaponLevels = new int[6];
		for(int i = 0; i < weaponLevels.Length; ++i)
			weaponLevels[i] = 0;
		
		availableRP = 0;
		weapon1Index = 0;
		weapon2Index = 2;

		weaponLevels[weapon1Index] = 1;
		weaponLevels[weapon2Index] = 1;

		nextLevel = 1;

		GameObject.DontDestroyOnLoad(gameObject);
	}
}
