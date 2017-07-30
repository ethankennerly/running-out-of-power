using UnityEngine;

public sealed class BodySelector : MonoBehaviour
{
	public InputController Replace()
	{
		Shop shop = Main.instance.shop;
		Upgrade upgrade = shop.GetEquipped(shop.bodyPart);
		GameObject bodyObject = ResourceUtil.ReplaceChild(gameObject, upgrade.prefab);
		return bodyObject.GetComponent<InputController>();
	}
}
