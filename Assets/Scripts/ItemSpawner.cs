using UnityEngine;
[System.Serializable]
public class ItemProbability
{
    public GameObject itemPrefab; // The prefab of the item to be spawned
    public float triggerChance;   // Chance of triggering (e.g., 0.1 for 10%)
}
public class ItemSpawner : MonoBehaviour
{
    public ItemProbability[] items; // Array of ItemProbability objects
    public Transform background; // The background or parent Transform for spawning items

    private void OnEnable()
    {
        Counter.CounterIncremented += OnCounterIncremented;
    }

    private void OnDisable()
    {
        Counter.CounterIncremented -= OnCounterIncremented;
    }

    private void OnCounterIncremented()
    {
        // Optionally, you can use this method to check conditions and then spawn items
        SpawnItems();
    }

    void SpawnItems()
    {
        foreach (var item in items)
        {
            if (ShouldTriggerEvent(item.triggerChance))
            {
                SpawnItem(item.itemPrefab);
            }
        }
    }

    bool ShouldTriggerEvent(float chance)
    {
        // Generate a random number between 0 and 1
        float randomValue = Random.Range(0f, 1f);

        // Compare the random value with the trigger chance
        return randomValue < chance;
    }

    void SpawnItem(GameObject prefab)
    {
        GameObject itemObject = Instantiate(prefab);

        // Ensure the prefab is a non-UI element with Transform
        Transform itemTransform = itemObject.transform;
        if (itemTransform == null)
        {
            Debug.LogError("Prefab does not have a Transform component.");
            return;
        }

        // Set position within the background
        float x = Random.Range(-background.localScale.x, background.localScale.x); // Adjust range based on background dimensions
        float y = Random.Range(-background.localScale.y, background.localScale.y); // Adjust range based on background dimensions
        itemTransform.position = new Vector3(8*x, 9/2*y, 0);

        itemObject.transform.SetParent(background, false);
    }
}
