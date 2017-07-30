using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class InputController : MonoBehaviour
{
	public Thruster thruster = new Thruster();

	public void Setup()
	{
		thruster.body = GetComponent<Rigidbody2D>();
		thruster.Setup();
	}

	public void UpdateTime(float deltaTime)
	{
		thruster.isActive = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
		thruster.Update(deltaTime);
	}
}
