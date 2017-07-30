using System.Collections.Generic;

public sealed class Shop
{
	public string fuelPart = "Fuels";

	public string selectedMenu;

	public List<string> menuNames = new List<string>();

	public Dictionary<string, List<Upgrade>> menus = new Dictionary<string, List<Upgrade>>();

	public Inventory inventory;

	public void Setup()
	{
		menuNames.Clear();
		menuNames.Add(fuelPart);

		menus.Clear();
		List<Upgrade> fuels = new List<Upgrade>();
		Upgrade fuel;

		fuel = new Upgrade();
		fuel.part = fuelPart;
		fuel.name = "Water";
		fuel.cost = 0;
		fuel.description = "Add air to propel.";
		fuel.prefab = fuelPart + "/Water";
		fuels.Add(fuel);

		fuel = new Upgrade();
		fuel.part = fuelPart;
		fuel.name = "Soda";
		fuel.cost = 10;
		fuel.description = "Pressurized air in water.";
		fuel.prefab = fuelPart + "/Soda";
		fuels.Add(fuel);

		menus.Add(fuelPart, fuels);

		inventory = Main.instance.inventory;
	}

	public Upgrade GetEquipped(string part)
	{
		string itemId = inventory.GetEquipped(part);
		if (itemId == null)
		{
			return menus[part][0];
		}
		List<Upgrade> upgrades = menus[part];
		for (int index = 0, end = upgrades.Count; index < end; ++index)
		{
			Upgrade upgrade = upgrades[index];
			if (upgrade.name == itemId)
			{
				return upgrade;
			}
		}
		return null;
	}

	public void Toggle(Upgrade upgrade)
	{
		bool isAnyEquipped = inventory.Toggle(upgrade.name, upgrade.part, upgrade.cost);
		if (!isAnyEquipped)
		{
			MayEquipFirst(upgrade.part);
		}
	}

	private void MayEquipFirst(string part)
	{
		if (!inventory.equips.ContainsKey(part) || inventory.equips[part] == null)
		{
			inventory.equips[part] = menus[part][0].name;
		}
	}

	public string GetNextState(Upgrade upgrade)
	{
		string itemId = upgrade.name;
		if (inventory.Count(itemId) <= 0 && upgrade.cost > 0)
		{
			return "buy";
		}
		MayEquipFirst(upgrade.part);
		if (inventory.IsEquipped(itemId))
		{
			return "unequip";
		}
		return "equip";
	}
}
