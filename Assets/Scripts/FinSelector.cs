using UnityEngine;

public sealed class FinSelector : MonoBehaviour
{
	public Rigidbody2D Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.finPart);
		GameObject finObject = ResourceUtil.ReplaceChild(gameObject, upgrade.prefab);

		Rigidbody2D finBody = finObject.GetComponent<Rigidbody2D>();
		return finBody;
	}
}
