using UnityEngine;

public sealed class MainView : MonoBehaviour
{
	public GameObject result;
	public CompleteCameraController cameraController;

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
	}
}
