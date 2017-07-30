using UnityEngine;

public sealed class NoseSelector : MonoBehaviour
{
	public Rigidbody2D Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.nosePart);
		GameObject noseObject = ResourceUtil.ReplaceChild(gameObject, upgrade.prefab);

		Rigidbody2D noseBody = noseObject.GetComponent<Rigidbody2D>();
		return noseBody;
	}
}
