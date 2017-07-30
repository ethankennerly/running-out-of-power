using UnityEngine;

public sealed class FuelSelector : MonoBehaviour
{
	public ParticleSystem particles;

	public GameObject Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.fuelPart);
		GameObject child = transform.GetChild(0).gameObject;
		GameObject go;
		if (upgrade == null)
		{
			go = child;
		}
		else
		{
			Debug.Log("FuelSelector.Replace: " + upgrade.name + " prefab " + upgrade.prefab);
			go = (GameObject)Instantiate(Resources.Load(upgrade.prefab));
			Destroy(child);
			go.transform.SetParent(transform, false);
		}
		particles = go.GetComponentInChildren<ParticleSystem>();
		return go;
	}
}
