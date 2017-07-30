using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Nozzle : MonoBehaviour
{
	public GameObject view;
	public ParticleSystem particles;
	public Rigidbody2D connectedBody;

	public float torqueMultiplier = 0.0f;
	public float maxTorqueMultiplier = 0.0f;

	private float degreePerTorqueMultiplier = 90.0f;

	public void Setup()
	{
		gameObject.transform.SetParent(connectedBody.gameObject.transform, false);
		Rigidbody2D body = GetComponent<Rigidbody2D>();
		body.gameObject.transform.SetParent(gameObject.transform, false);
		particles.gameObject.transform.SetParent(view.transform, false);
		body.GetComponent<FixedJoint2D>().connectedBody = connectedBody;
	}

	public void UpdateTime()
	{
		torqueMultiplier = Mathf.Clamp(torqueMultiplier, -maxTorqueMultiplier, maxTorqueMultiplier);
		UpdateRotation(view);
	}

	private void UpdateRotation(GameObject gameObject)
	{
		Vector3 rotation = gameObject.transform.localEulerAngles;
		rotation.z = torqueMultiplier * degreePerTorqueMultiplier;
		gameObject.transform.localEulerAngles = rotation;
	}
}
