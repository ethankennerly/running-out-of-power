using UnityEngine;

[RequireComponent(typeof(ConstantForce2D), typeof(Rigidbody2D))]
public sealed class InputController : MonoBehaviour
{
	public GameObject result;
	public Thruster thruster = new Thruster();

	public void Setup()
	{
		thruster.body = GetComponent<Rigidbody2D>();
		thruster.force = GetComponent<ConstantForce2D>();
		thruster.Setup();
	}

	public void Update()
	{
		thruster.isActive = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
		UpdateGameOver();
		thruster.Update(Time.deltaTime);
	}

	private void UpdateGameOver()
	{
		result.SetActive(thruster.isExhausted);
	}
}
