public sealed class ShopInventory
{
	public string fuelPart = "Fuel";

	public string selectedMenu;

	List <string> menuNames = new List<string>();
	public List<List<Upgrade>> menus = new List<string, List<Upgrade>>();

	public void Setup()
	{
		menuNames.Clear();
		menuNames.Add(fuelPart);

		menus.Clear();
		List<Upgrade> fuels = new List<Upgrade>();
		Upgrade fuel = new Upgrade();
		fuel.part = fuelPart;
		fuel.name = "Soda";
		fuel.cost = 0;
		fuel.description = "Pressurized air in water.";
		fuel.prefab = fuelPart + "/Soda";
		fuels.Add(fuel);
		menus.Add(fuels);
	}
}
