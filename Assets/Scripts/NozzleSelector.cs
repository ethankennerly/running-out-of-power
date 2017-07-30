using UnityEngine;

public sealed class NozzleSelector : MonoBehaviour
{
	public Nozzle Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.nozzlePart);
		GameObject nozzleObject = ResourceUtil.ReplaceChild(gameObject, upgrade.prefab);

		Nozzle nozzle = nozzleObject.GetComponent<Nozzle>();
		return nozzle;
	}
}
