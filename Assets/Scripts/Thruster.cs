using UnityEngine;

[System.Serializable]
public sealed class Thruster
{
	public bool isActive = false;
	public bool hasFuel = true;
	public bool isEnabled = true;
	public bool isExhausted = false;
	public bool isExhaustedNow = false;
	public float fuel = 5.0f;
	public float forceRatio = 1.0f;
	public float baseFuel;
	public float fuelRate = -1.0f;
	public float fuelRateIdle = -0.01f;
	private float fuelRateIdleNow = 0.0f;
	public float fuelRatio = 1.0f;

	public ConstantForce2D force;
	public Vector2 baseForce = new Vector2();

	public Rigidbody2D body;
	public int distance;

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
		UpdateIsExhausted();
		UpdateFuelObject();
		UpdateForce();
		force.enabled = isEnabled;
		distance = (int)body.position.x;
		UpdateParticles();
	}

	private void UpdateFuelAmount(float deltaTime)
	{
		hasFuel = fuel > 0.0f;
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
		if (fuel < 0.0f)
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
		fuelObject.SetActive(fuelRatio > 0.0f);
	}

	private void UpdateForce()
	{
		float efficiency = isEnabled ? forceRatio : 0.0f;
		Vector2 relativeForce = efficiency * baseForce;
		force.relativeForce = relativeForce;
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

	public void UpdateIsExhausted()
	{
		isExhaustedNow = false;
		if (!isExhausted)
		{
			isExhausted = !hasFuel && body.velocity.sqrMagnitude <= 0.001f;
			isExhaustedNow = isExhausted;
		}
	}
}
