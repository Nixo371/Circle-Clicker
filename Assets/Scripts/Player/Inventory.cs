using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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
}
