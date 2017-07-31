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

		NoseSelector nose = GetComponentInChildren<NoseSelector>();
		input.thruster.nose.body = nose.Replace();

		FinSelector fin = GetComponentInChildren<FinSelector>();
		input.thruster.fin.body = fin.Replace();

		NozzleSelector nozzleSelector = GetComponentInChildren<NozzleSelector>();
		Nozzle nozzle = nozzleSelector.Replace();
		input.thruster.nozzle = nozzle;

		return input;
	}
}
