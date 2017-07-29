using UnityEngine;

[RequireComponent(typeof(ConstantForce2D))]
public sealed class InputController : MonoBehaviour
{
	public Thruster thruster = new Thruster();

	private void Start()
	{
		thruster.force = gameObject.GetComponent<ConstantForce2D>();
	}

	private void Update()
	{
		thruster.enabled = Input.GetMouseButton(0);
		thruster.Update();
	}
}
