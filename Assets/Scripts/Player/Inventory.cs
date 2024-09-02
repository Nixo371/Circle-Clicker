using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour, Saveable
{
    public string path = "inventory";
	// ID -> count
	private Dictionary<int, int> items = new Dictionary<int, int>();

    public void registerItem(int id, int count = 0)
    {
        items.Add(id, count);
    }
    public void addItem(int id, int count = 1)
    {
        if (!items.ContainsKey(id))
        {
            registerItem(id);
        }
        items[id] += count;
	}

    public bool removeItem(int id, int count) {
        items[id] -= count;
        if (items[id] < 0)
        {
            items[id] += count;
            return false;
        }
        return true;
    }

    public int getItemCount(int id)
    {
        if (items.ContainsKey(id))
        {
            return items[id];
        }
        return 0;
    }

    public void load()
    {
		string load_path = Path.Combine(Application.persistentDataPath, path);

		if (File.Exists(load_path))
        {
            string json = File.ReadAllText(load_path);
            string[] lines = json.Split('\n');
			for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                
                if (line[0] == '{' || line[0] == '}')
                {
                    // Start or end, no data
                    continue;
                }

                string[] values = line.Split(':');
                int key = int.Parse(values[0].Trim());
                int value = int.Parse(values[1].Trim());

                items[key] = value;
            }
        }
    }

    public void save()
    {
		string save_path = Path.Combine(Application.persistentDataPath, path);

		string json = "{\n";
        foreach (KeyValuePair<int, int> kvp in items)
        {
            int key = kvp.Key;
            int value = kvp.Value;

            json += key.ToString() + ": " + value.ToString() + "\n";
        }
        json += "}";

		File.WriteAllText(save_path, json);
	}
}
