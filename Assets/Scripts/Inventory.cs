using System.Collections.Generic;

public sealed class Inventory
{
	public string coins = "coins";
	public string longest = "longest";

	public Dictionary<string, int> items = new Dictionary<string, int>();
	public Dictionary<string, int> adds = new Dictionary<string, int>();

	public void Setup()
	{
		if (!items.ContainsKey(coins))
		{
			items[coins] = 0;
		}
	}

	public int Count(string itemId, bool isTotal)
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
}
