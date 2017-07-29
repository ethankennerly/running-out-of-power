using UnityEngine;

[System.Serializable]
public sealed class Thruster
{
	public ConstantForce2D force;
	public bool enabled = false;

	public void Update()
	{
		force.enabled = enabled;
	}
}
