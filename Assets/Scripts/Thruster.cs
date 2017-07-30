using UnityEngine;

[System.Serializable]
public sealed class Thruster
{
	public bool isActive = false;

	public Fuel fuel;

	public bool isExhausted = false;
	public bool isExhaustedNow = false;

	public Rigidbody2D body;
	public int distance = 0;

	public Nose nose;

	public Fin fin;

	public void Setup()
	{
		fuel.Setup();
		nose.connectedBody = body;
		nose.Setup();
		fin.connectedBody = body;
		fin.Setup();
	}

	public void Update(float deltaTime)
	{
		fuel.isActive = isActive;
		fuel.UpdateTime(deltaTime);
		UpdateIsExhausted();
		UpdateForce();
		distance = (int)body.position.magnitude;
	}

	private void UpdateForce()
	{
		if (fuel.isEnabled)
		{
			body.AddRelativeForce(fuel.relativeForce);
		}
	}

	public void UpdateIsExhausted()
	{
		isExhaustedNow = false;
		if (!isExhausted)
		{
			isExhausted = !fuel.hasFuel && body.velocity.sqrMagnitude <= 0.001f;
			isExhaustedNow = isExhausted;
		}
	}
}
