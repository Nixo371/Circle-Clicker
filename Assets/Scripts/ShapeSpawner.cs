using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShapeSpawner : MonoBehaviour, ClickObserver
{
    public ClickableBox clickableBox;
    public WindowInfo windowInfo;

	public class ByRarity : IComparer<GameObject>
	{
		public int Compare(GameObject x, GameObject y)
		{
			ISpawnable xSpawnable = x.GetComponent<ISpawnable>();
			ISpawnable ySpawnable = y.GetComponent<ISpawnable>();
			int xRarity = xSpawnable.getRarity();
			int yRarity = ySpawnable.getRarity();

			return xRarity - yRarity;
		}
	}

	// A set that is sorted from rarest (highest rarity) to most common
	SortedSet<GameObject> spawnables = new SortedSet<GameObject>(new ByRarity());

	int scale;
	int notSpawnableBorder;
	int w;
	int h;

	void Start()
    {
        clickableBox.register(this);

		scale = 8;
		notSpawnableBorder = (int) (5.5 * scale * 1.1);
		w = windowInfo.width - (2 * notSpawnableBorder);
		h = windowInfo.height - (2 * notSpawnableBorder);

		string[] shapePrefabs = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Shapes" });
		foreach (string shape in shapePrefabs)
		{
			string shapePath = AssetDatabase.GUIDToAssetPath(shape);
			GameObject shapeObject = (GameObject) AssetDatabase.LoadAssetAtPath(shapePath, typeof(GameObject));
			register(shapeObject);
		}
	}

	public void register(GameObject spawnable)
	{
		spawnables.Add(spawnable);
		UnityEngine.Debug.Log(spawnable.gameObject.name + " registered");
	}

    public void onClick()
    {
		float random = Random.value;
		foreach (GameObject prefab in spawnables)
		{
			ISpawnable spawnable = prefab.GetComponent<ISpawnable>();
			int rarity = spawnable.getRarity();
			if (random < 1.0f / rarity)
			{
				int x = (int) Mathf.Floor(Random.value * w) - (w / 2);
				int y = (int) Mathf.Floor(Random.value * h) - (h / 2);
				spawnable.spawn(x, y, scale);
			}
		}
    }
}