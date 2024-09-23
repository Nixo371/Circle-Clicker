using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private List<GameObject> menuObjects = new List<GameObject>();
	private LinkedList<GameObject> openMenus = new LinkedList<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
		string[] menuPrefabs = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Menus/Prefabs" });
		foreach (string menu in menuPrefabs)
		{
			string menuPath = AssetDatabase.GUIDToAssetPath(menu);
			GameObject menuObject = (GameObject) AssetDatabase.LoadAssetAtPath(menuPath, typeof(GameObject));
			menuObjects.Add(menuObject);
			Debug.Log("Added menu at: " + menuPath);
		}
	}

    // Update is called once per frame
    void Update()
    {
		foreach (GameObject menu in menuObjects)
		{
			GameObject newMenu = Instantiate(menu);
			IMenu m = newMenu.GetComponent<IMenu>();
			if (!m.checkOpen())
			{
				Destroy(newMenu);
			}
			UnityEngine.Debug.Log("attempted to instantiate menu: " + menu.ToString());
		}
	}
}
