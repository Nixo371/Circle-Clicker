using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{

	public PlayerSave playerSave;
	public Inventory inventory;
	string playerSavePath;
	string inventoryPath;
	// Start is called before the first frame update
	void Start()
	{
		playerSavePath = Path.Combine(Application.persistentDataPath, playerSave.path);
		if (File.Exists(playerSavePath))
		{
			string json = File.ReadAllText(playerSavePath);
			JsonUtility.FromJsonOverwrite(json, playerSave);
			FindObjectOfType<Counter>().refresh();
		}
		else
		{
			playerSave.clickCount = 0;
		}

		inventory.load();
	}

	public void save()
	{
		string playerJSON = JsonUtility.ToJson(playerSave);
		
		File.WriteAllText(playerSavePath, playerJSON);

		inventory.save();
	}
}
