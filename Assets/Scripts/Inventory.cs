using System.Collections.Generic;

public sealed class Inventory
{
	public string coins = "coins";
	public string longest = "longest";

	public Dictionary<string, int> items = new Dictionary<string, int>();
	public Dictionary<string, int> adds = new Dictionary<string, int>();
	public Dictionary<string, string> equips = new Dictionary<string, string>();

	public void Setup()
	{
		if (!items.ContainsKey(coins))
		{
			items[coins] = 0;
		}
	}

	public int Count(string itemId, bool isTotal = true)
	{
		Dictionary<string, int> hash = isTotal ? items : adds;
		if (!hash.ContainsKey(itemId))
		{
			return 0;
		}
		return hash[itemId];
	}

	public void Add(string itemId, int quantity)
	{
		if (!items.ContainsKey(itemId))
		{
			items[itemId] = 0;
		}
		items[itemId] += quantity;
		if (quantity > 0)
		{
			adds[itemId] = quantity;
		}
	}

	public bool Upgrade(string itemId, int quantity)
	{
		if (!items.ContainsKey(itemId))
		{
			items[itemId] = 0;
		}
		bool isLarger = items[itemId] < quantity;
		if (isLarger)
		{
			items[itemId] = quantity;
		}
		return isLarger;
	}

	public string GetNextState(string itemId)
	{
		if (Count(itemId) <= 0)
		{
			return "buy";
		}
		if (IsEquipped(itemId))
		{
			return "unequip";
		}
		return "equip";
	}

	public bool Buy(string itemId, int cost)
	{
		if (Count(coins) < cost)
		{
			return false;
		}
		Add(itemId, 1);
		Add(coins, -cost);
		return true;
	}

	public void Toggle(string itemId, string part, int cost)
	{
		if (Count(itemId) <= 0)
		{
			Buy(itemId, cost);
			return;
		}
		if (!equips.ContainsKey(part) || equips[part] != itemId)
		{
			equips[part] = itemId;
			return;
		}
		equips[part] = null;
	}

	public bool IsEquipped(string itemId)
	{
		foreach (var pair in equips)
		{
			if (pair.Value == itemId)
			{
				return true;
			}
		}
		return false;
	}
}
