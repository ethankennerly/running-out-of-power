using UnityEngine;

public sealed class BodySelector : MonoBehaviour
{
	public InputController Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.bodyPart);
		GameObject child = transform.GetChild(0).gameObject;
		GameObject go;
		if (upgrade == null)
		{
			go = child;
		}
		else
		{
			Debug.Log("BodySelector.Replace: " + upgrade.name + " prefab " + upgrade.prefab);
			go = (GameObject)Instantiate(Resources.Load(upgrade.prefab));
			Destroy(child);
			go.transform.SetParent(transform, false);
		}
		return go.GetComponent<InputController>();
	}
}
