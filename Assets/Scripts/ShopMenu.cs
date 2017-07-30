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
		button.onClick.AddListener(OpenMenu);
		Update();
	}

	private void Update()
	{
		if (index >= shop.menuNames.Count)
		{
			gameObject.SetActive(false);
			return;
		}
		gameObject.SetActive(true);
		nameText.text = shop.menuNames[index];
	}

	private void OpenMenu()
	{
		shop.selectedMenu = shop.menuNames[index];
		menu.SetActive(true);
	}
}
