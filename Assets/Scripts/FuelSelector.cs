using UnityEngine;

public sealed class FuelSelector : MonoBehaviour
{
	public Fuel Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.fuelPart);
		GameObject fuelObject = ResourceUtil.ReplaceChild(gameObject, upgrade.prefab);

		Fuel fuel = fuelObject.GetComponent<Fuel>();
		fuel.fuelObject = fuelObject;
		fuel.particles = fuelObject.GetComponentInChildren<ParticleSystem>();
		return fuel;
	}
}
