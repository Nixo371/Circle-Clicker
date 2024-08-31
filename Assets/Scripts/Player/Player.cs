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

		inventoryPath = Path.Combine(Application.persistentDataPath, inventory.path);
		if (File.Exists(inventoryPath))
		{
			string json = File.ReadAllText(inventoryPath);
			JsonUtility.FromJsonOverwrite(json, inventory);
		}
	}

	public void save()
	{
		string playerJSON = JsonUtility.ToJson(playerSave);
		string inventoryJSON = JsonUtility.ToJson(inventory);
		
		File.WriteAllText(playerSavePath, playerJSON);
		File.WriteAllText(inventoryPath, inventoryJSON);
	}
}
