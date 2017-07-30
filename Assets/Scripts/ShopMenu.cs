using UnityEngine;
using UnityEngine.UI;

public sealed class ShopMenu : MonoBehaviour
{
	public Shop shop;
	public Text nameText;
	public Button button;
	public GameObject menu;
	public int index = -1;

	private void Start()
	{
		shop = Main.instance.shop;
		index = transform.GetSiblingIndex();
		Setup();
	}

	private void Setup()
	{
		nameText.text = shop.menuNames[index];
		button.onClick.AddListener(OpenMenu);
	}

	private void OpenMenu()
	{
		shop.selectedMenu = shop.menuNames[index];
		menu.SetActive(true);
	}
}
