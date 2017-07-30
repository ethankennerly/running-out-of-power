using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ShopTile : MonoBehaviour
{
	public Text nameText;
	public Text description;
	public Text cost;
	public Animator anim;
	public Button button;
	public int index = -1;

	public Shop shop;
	public Upgrade upgrade;

	private void Start()
	{
		shop = Main.instance.shop;
		index = transform.GetSiblingIndex();
		button.onClick.AddListener(Toggle);
	}

	private void Toggle()
	{
		shop.Toggle(upgrade);
	}

	private void Update()
	{
		List<Upgrade> upgrades = shop.menus[shop.selectedMenu];
		if (index >= upgrades.Count)
		{
			gameObject.SetActive(false);
			return;
		}
		gameObject.SetActive(true);
		upgrade = upgrades[index];
		nameText.text = upgrade.name;
		description.text = upgrade.description;
		cost.text = upgrade.cost.ToString();
		anim.Play(shop.GetNextState(upgrade));
	}
}
