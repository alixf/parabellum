using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
	public int level;
	public Transform endScreen;
	public GUIText endText;

	private int enemiesCount;
	public int enemiesShot;

	private bool end;

	void Awake()
	{
		enemiesCount = GameObject.FindGameObjectsWithTag("enemy").Length;
		enemiesShot = 0;
		end = false;
	}

	void Update ()
	{
		if(GameObject.FindGameObjectsWithTag("enemy").Length <= 0 && !end)
		{
			int RPEarned = 0;
			if((float)enemiesShot / (float)enemiesCount >= 0.33f)
				RPEarned++;
			if((float)enemiesShot / (float)enemiesCount >= 0.66f)
				RPEarned++;
			if((float)enemiesShot / (float)enemiesCount >= 0.99f)
				RPEarned++;
			// DataManager.Instance.nextLevel++;
			DataManager.Instance.availableRP += RPEarned;

			endText.text = "Level "+level+"\n\n"+
			"Enemies : " + enemiesShot + " / " + enemiesCount+"\n\n"+
			"You earned "+RPEarned+" Research Points\n\n"+
			"Press Space to Continue";
			endScreen.gameObject.SetActive(true);

			end = true;
		}
		if(end)
		{
			if(Input.GetKeyDown("space"))
			{
				Application.LoadLevel(2);
			}
		}
	}
}
