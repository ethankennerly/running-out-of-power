using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class InventoryText : MonoBehaviour
{
	private Text text;
	public bool isTotal = true;
	public string itemId = "coins";

	private void Start()
	{
		text = GetComponent<Text>();
	}

	private void Update()
	{
		text.text = Main.instance.inventory.Count(itemId, isTotal).ToString();
	}
}
