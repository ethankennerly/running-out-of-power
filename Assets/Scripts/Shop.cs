using System.Collections.Generic;

public sealed class Shop
{
	public string bodyPart = "Bodies";
	public string finPart = "Fins";
	public string fuelPart = "Fuels";
	public string nosePart = "Noses";
	public string nozzlePart = "Nozzles";

	public string selectedMenu;

	public List<string> menuNames = new List<string>();

	public Dictionary<string, List<Upgrade>> menus = new Dictionary<string, List<Upgrade>>();

	public Inventory inventory;

	public void Setup()
	{
		menuNames.Clear();

		menus.Clear();
		AddFuelsMenu();
		AddBodiesMenu();
		AddNosesMenu();
		AddFinsMenu();
		AddNozzlesMenu();

		inventory = Main.instance.inventory;
	}

	private void AddFuelsMenu()
	{
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
		menuNames.Add(fuelPart);
	}

	private void AddBodiesMenu()
	{
		List<Upgrade> bodies = new List<Upgrade>();
		Upgrade body;

		body = new Upgrade();
		body.part = bodyPart;
		body.name = "Glass";
		body.cost = 0;
		body.description = "Thick and heavy.";
		body.prefab = bodyPart + "/Glass";
		bodies.Add(body);

		body = new Upgrade();
		body.part = bodyPart;
		body.name = "Aluminum";
		body.cost = 20;
		body.description = "Thin and light.";
		body.prefab = bodyPart + "/Aluminum";
		bodies.Add(body);

		menus.Add(bodyPart, bodies);
		menuNames.Add(bodyPart);
	}

	private void AddNosesMenu()
	{
		List<Upgrade> noses = new List<Upgrade>();
		Upgrade nose;

		nose = new Upgrade();
		nose.part = nosePart;
		nose.name = "Rubber Block";
		nose.cost = 0;
		nose.description = "Heavy. Blocks resist air.";
		nose.prefab = nosePart + "/RubberBlock";
		noses.Add(nose);

		nose = new Upgrade();
		nose.part = nosePart;
		nose.name = "Cardboard Cone";
		nose.cost = 25;
		nose.description = "Cones flow through air.";
		nose.prefab = nosePart + "/CardboardCone";
		noses.Add(nose);

		menus.Add(nosePart, noses);
		menuNames.Add(nosePart);
	}

	private void AddFinsMenu()
	{
		List<Upgrade> fins = new List<Upgrade>();
		Upgrade fin;

		fin = new Upgrade();
		fin.part = finPart;
		fin.name = "None";
		fin.cost = 0;
		fin.description = "Rotates easily.";
		fin.prefab = finPart + "/None";
		fins.Add(fin);

		fin = new Upgrade();
		fin.part = finPart;
		fin.name = "Cardboard Fins";
		fin.cost = 50;
		fin.description = "Fins resist rotation.";
		fin.prefab = finPart + "/Cardboard";
		fins.Add(fin);

		menus.Add(finPart, fins);
		menuNames.Add(finPart);
	}

	private void AddNozzlesMenu()
	{
		List<Upgrade> nozzles = new List<Upgrade>();
		Upgrade nozzle;

		nozzle = new Upgrade();
		nozzle.part = nozzlePart;
		nozzle.name = "Bottleneck";
		nozzle.cost = 0;
		nozzle.description = "Sprays fuel.";
		nozzle.prefab = nozzlePart + "/Bottleneck";
		nozzles.Add(nozzle);

		nozzle = new Upgrade();
		nozzle.part = nozzlePart;
		nozzle.name = "Gimbal";
		nozzle.cost = 100;
		nozzle.description = "Tap UP or DOWN to steer.";
		nozzle.prefab = nozzlePart + "/Gimbal";
		nozzles.Add(nozzle);

		menus.Add(nozzlePart, nozzles);
		menuNames.Add(nozzlePart);
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
