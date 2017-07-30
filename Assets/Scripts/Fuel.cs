using UnityEngine;

public sealed class Fuel : MonoBehaviour
{
	public bool hasFuel = true;
	public bool isActive = false;
	public bool isEnabled = true;
	public float fuel = 0.5f;
	public float forceRatio = 1.0f;
	public float forceRatioIdle = 0.0f;
	private float baseFuel;
	public float fuelRate = -1.0f;
	public float fuelRateIdle = -0.01f;
	private float fuelRateIdleNow = 0.0f;
	public float fuelRatio = 1.0f;
	public float minimum = 0.01f;

	public Vector2 baseForce = new Vector2(0, 300);
	public Vector2 relativeForce;

	public ParticleSystem particles;

	public GameObject fuelObject;
	private Vector3 baseFuelScale;

	public void Setup()
	{
		baseFuel = fuel;
		baseFuelScale = fuelObject.transform.localScale;
	}

	public void UpdateTime(float deltaTime)
	{
		UpdateFuelAmount(deltaTime);
		UpdateForce();
		UpdateFuelObject();
		UpdateParticles();
	}

	private void UpdateFuelAmount(float deltaTime)
	{
		hasFuel = fuel > minimum;
		isEnabled = isActive && hasFuel;
		if (isEnabled)
		{
			fuel += deltaTime * fuelRate;
			fuelRateIdleNow = fuelRateIdle;
		}
		else if (hasFuel)
		{
			fuel += deltaTime * fuelRateIdleNow;
		}
		if (fuel < minimum)
		{
			fuel = 0.0f;
		}
		fuelRatio = fuel / baseFuel;
	}

	private void UpdateFuelObject()
	{
		Vector3 scale = fuelObject.transform.localScale;
		scale.y = fuelRatio * baseFuelScale.y;
		fuelObject.transform.localScale = scale;
		fuelObject.SetActive(hasFuel);
	}

	private void UpdateForce()
	{
		float efficiency = isEnabled ? forceRatio : forceRatioIdle;
		relativeForce = efficiency * baseForce;
	}

	private void UpdateParticles()
	{
		if (particles != null)
		{
			ParticleSystem.EmissionModule emission = particles.emission;
			emission.enabled = isEnabled;

			ParticleSystem.SizeOverLifetimeModule size = particles.sizeOverLifetime;
			size.enabled = true;
			size.sizeMultiplier = forceRatio;
		}
	}
}
