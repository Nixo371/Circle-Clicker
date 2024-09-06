using UnityEngine;

public interface ISpawnable
{
	public void spawn(int x, int y, int scale);
	public int getRarity();
	public GameObject getGameObject();
}