using UnityEngine;

[RequireComponent(typeof(ConstantForce2D))]
public sealed class InputController : MonoBehaviour
{
	public ConstantForce2D force;

	private void Start()
	{
		force = gameObject.GetComponent<ConstantForce2D>();
	}

	private void Update()
	{
		force.enabled = Input.GetMouseButton(0);
	}
}
