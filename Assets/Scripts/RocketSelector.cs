using UnityEngine;

public sealed class RocketSelector : MonoBehaviour
{
	// Fuel selector becomes child of body.
	// So that particles follow body.
	public InputController Replace()
	{
		BodySelector body = GetComponentInChildren<BodySelector>();
		InputController input = body.Replace();

		FuelSelector fuel = GetComponentInChildren<FuelSelector>();
		input.thruster.fuel = fuel.Replace();
		input.thruster.fuel.fuelObject.transform.SetParent(input.gameObject.transform, false);
		return input;
	}
}
