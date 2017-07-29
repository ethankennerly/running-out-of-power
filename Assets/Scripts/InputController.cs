using UnityEngine;

[RequireComponent(typeof(ConstantForce2D))]
public sealed class InputController : MonoBehaviour
{
	public GameObject result;
	public Thruster thruster = new Thruster();

	private void Start()
	{
		thruster.force = gameObject.GetComponent<ConstantForce2D>();
		thruster.Setup();
	}

	private void Update()
	{
		thruster.isActive = Input.GetMouseButtonDown(0);
		UpdateGameOver();
		thruster.Update(Time.deltaTime);
	}

	private void UpdateGameOver()
	{
		result.SetActive(!thruster.hasFuel);
	}
}
