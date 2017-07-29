using UnityEngine;

public sealed class Explosion : MonoBehaviour
{
	public Rigidbody2D[] bodies;
	public float magnitude = 100.0f;

	private void Start()
	{
		if (bodies == null || bodies.Length == 0)
		{
			bodies = GetComponentsInChildren<Rigidbody2D>();
		}
	}

	private void Update()
	{
		for (int index = 0, end = bodies.Length; index < end; ++index)
		{
			Vector2 randomForce = Random.insideUnitCircle;
			randomForce = magnitude * randomForce.normalized;
			bodies[index].AddForce(randomForce);
		}
	}
}
