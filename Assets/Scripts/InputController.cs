using UnityEngine;

[RequireComponent(typeof(ConstantForce2D), typeof(Rigidbody2D))]
public sealed class InputController : MonoBehaviour
{
	public GameObject result;
	public Thruster thruster = new Thruster();

	private void Start()
	{
		thruster.body = GetComponent<Rigidbody2D>();
		thruster.force = GetComponent<ConstantForce2D>();
		thruster.Setup();
	}

	private void Update()
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
