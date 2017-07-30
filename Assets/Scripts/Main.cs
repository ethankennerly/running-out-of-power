using System.Collections.Generic;

public sealed class Main
{
	public static Main instance = new Main();

	public MainView view;
	public RocketSelector rocket;
	public InputController input;
	public Inventory inventory = new Inventory();
	public Shop shop = new Shop();

	public void Setup()
	{
		inventory.Setup();
		shop.Setup();
		input = rocket.Replace();
		input.Setup();
	}

	public void Update(float deltaTime)
	{
		input.UpdateTime(deltaTime);
		UpdateGameOver();
	}

	private void UpdateGameOver()
	{
		if (input.thruster.isExhaustedNow)
		{
			inventory.Add(inventory.coins, input.thruster.distance);
			inventory.Upgrade(inventory.longest, input.thruster.distance);
			view.result.SetActive(true);
		}
	}
}
