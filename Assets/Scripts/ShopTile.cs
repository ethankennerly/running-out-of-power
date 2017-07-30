using UnityEngine;
using UnityEngine.UI;

public sealed class ShopTile : MonoBehaviour
{
	public Shop shop;
	public Inventory inventory;
	public Text nameText;
	public Text description;
	public Text cost;
	public Animator anim;
	public Button button;
	public int index = -1;
	public Upgrade upgrade;

	private void Start()
	{
		shop = Main.instance.shop;
		inventory = Main.instance.inventory;
		index = transform.GetSiblingIndex();
		Setup();
	}

	private void Setup()
	{
		upgrade = shop.menus[shop.selectedMenu][index];
		nameText.text = upgrade.name;
		description.text = upgrade.description;
		cost.text = upgrade.cost.ToString();
		button.onClick.AddListener(Toggle);
	}

	private void Toggle()
	{
		inventory.Toggle(upgrade.name, upgrade.part, upgrade.cost);
	}

	private void Update()
	{
		anim.Play(inventory.GetNextState(upgrade.name));
	}
}
