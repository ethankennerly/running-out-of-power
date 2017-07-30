using UnityEngine;

public sealed class MainBehaviour : MonoBehaviour
{
	private void Start()
	{
		Main.instance.input = FindObjectOfType<InputController>();
		Main.instance.fuel = FindObjectOfType<FuelSelector>();
		Main.instance.Setup();
	}

	private void Update()
	{
		Main.instance.Update();
	}
}
