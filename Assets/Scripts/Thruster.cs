using UnityEngine;

[System.Serializable]
public sealed class Thruster
{
	public bool isActive = false;
	public bool hasFuel = true;
	public bool isEnabled = true;
	[Range(0.0f, 5.0f)]
	public float fuel = 5.0f;
	public float baseFuel;
	public float fuelRate = -1.0f;

	public ConstantForce2D force;
	public Vector2 baseForce = new Vector2();

	public void Setup()
	{
		baseFuel = fuel;
	}

	public void Update(float deltaTime)
	{
		hasFuel = fuel > 0.0f;
		isEnabled = isActive && hasFuel;
		if (isEnabled)
		{
			fuel += deltaTime * fuelRate;
			if (fuel < 0.0f)
			{
				fuel = 0.0f;
			}
		}
		UpdateForce();
		force.enabled = isEnabled;
	}

	private void UpdateForce()
	{
		float efficiency = fuel / baseFuel;
		Vector2 relativeForce = efficiency * baseForce;
		force.relativeForce = relativeForce;
	}
}
