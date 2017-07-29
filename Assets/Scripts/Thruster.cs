using UnityEngine;

[System.Serializable]
public sealed class Thruster
{
	public bool isActive = false;
	public bool hasFuel = true;
	public bool isEnabled = true;
	public float fuel = 5.0f;
	public float fuelRate = -1.0f;
	public ConstantForce2D force;

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
		force.enabled = isEnabled;
	}
}
