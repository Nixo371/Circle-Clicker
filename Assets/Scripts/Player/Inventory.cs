using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Item, int> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new Dictionary<Item, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void registerItem(Item item, int count = 0)
    {
        items.Add(item, count);
    }
    public void addItem(Item item, int count)
    {
        items[item] += count;
    }

    public bool removeItem(Item item, int count) {
        items[item] -= count;
        if (items[item] < 0)
        {
            items[item] += count;
            return false;
        }
        return true;
    }
}
