using UnityEngine;

public sealed class MainView : MonoBehaviour
{
	public GameObject result;
	public CompleteCameraController cameraController;
	public int cheatCoins = 0;

	private void Start()
	{
		Main.instance.rocket = FindObjectOfType<RocketSelector>();
		Main.instance.view = this;
		Main.instance.Setup();
		cameraController.player = Main.instance.input.gameObject;
		cameraController.Setup();
	}

	private void Update()
	{
		Main.instance.Update(Time.deltaTime);
		Main.instance.inventory.Add(Main.instance.inventory.coins, cheatCoins);
		cheatCoins = 0;
	}
}
