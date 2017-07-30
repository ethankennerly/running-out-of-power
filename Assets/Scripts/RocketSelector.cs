using UnityEngine;

public sealed class RocketSelector : MonoBehaviour
{
	// Fuel selector becomes child of body.
	// So that particles follow body.
	// Binds nose to body.
	public InputController Replace()
	{
		BodySelector body = GetComponentInChildren<BodySelector>();
		InputController input = body.Replace();

		FuelSelector fuel = GetComponentInChildren<FuelSelector>();
		input.thruster.fuel = fuel.Replace();
		input.thruster.fuel.fuelObject.transform.SetParent(input.gameObject.transform, false);

		NoseSelector nose = GetComponentInChildren<NoseSelector>();
		input.thruster.nose.body = nose.Replace();

		FinSelector fin = GetComponentInChildren<FinSelector>();
		input.thruster.fin.body = fin.Replace();

		return input;
	}
}
