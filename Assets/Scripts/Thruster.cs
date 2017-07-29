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
	public float fuelRatio = 1.0f;

	public ConstantForce2D force;
	public Vector2 baseForce = new Vector2();

	public ParticleSystem particles;

	public GameObject fuelObject;
	public Vector3 baseFuelScale;
	public Vector3 baseFuelPosition;

	public void Setup()
	{
		baseFuel = fuel;
		baseFuelScale = fuelObject.transform.localScale;
		baseFuelPosition = fuelObject.transform.localPosition;
	}

	public void Update(float deltaTime)
	{
		UpdateFuelAmount(deltaTime);
		UpdateFuelObject();
		isEnabled = isActive && hasFuel;
		UpdateForce();
		force.enabled = isEnabled;
		if (particles != null)
		{
			ParticleSystem.EmissionModule em = particles.emission;
			em.enabled = isEnabled;
		}
	}

	private void UpdateFuelAmount(float deltaTime)
	{
		hasFuel = fuel > 0.0f;
		if (isEnabled)
		{
			fuel += deltaTime * fuelRate;
			if (fuel < 0.0f)
			{
				fuel = 0.0f;
			}
		}
		fuelRatio = fuel / baseFuel;
	}

	private void UpdateFuelObject()
	{
		Vector3 scale = fuelObject.transform.localScale;
		scale.y = fuelRatio * baseFuelScale.y;
		fuelObject.transform.localScale = scale;
	}

	private void UpdateForce()
	{
		float efficiency = isEnabled ? fuelRatio : 0.0f;
		Vector2 relativeForce = efficiency * baseForce;
		force.relativeForce = relativeForce;
	}
}
