using System.Collections.Generic;

public sealed class Main
{
	public static Main instance = new Main();

	public InputController input;
	public Inventory inventory = new Inventory();
	public Shop shop = new Shop();

	public void Setup()
	{
		inventory.Setup();
		shop.Setup();
	}

	public void Update()
	{
		if (input.thruster.isExhaustedNow)
		{
			inventory.Add(inventory.coins, input.thruster.distance);
			inventory.Upgrade(inventory.longest, input.thruster.distance);
		}
	}
}
