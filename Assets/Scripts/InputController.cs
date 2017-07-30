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
		thruster.isActive = Input.GetMouseButtonDown(0) || Input.anyKeyDown;
		thruster.nozzle.Steer(GetCounterClockwise());
		thruster.Update(deltaTime);
	}

	private float GetCounterClockwise()
	{
		float key = GetCounterClockwiseArrowKey();
		if (key != 0.0f)
		{
			return key;
		}
		return GetCounterClockwiseMouse();
	}

	private float GetCounterClockwiseArrowKey()
	{
		float max = 0.0f;
		bool isCounterClockwise = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow);
		if (isCounterClockwise)
		{
			return -max;
		}
		bool isClockwise = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow);
		if (isClockwise)
		{
			return max;
		}
		return 0.0f;
	}

	private float GetCounterClockwiseMouse()
	{
		float max = 1.0f;
		bool isDown = Input.GetMouseButton(0);
		if (!isDown)
		{
			return 0.0f;
		}
		float ratio = Input.mousePosition.y / Screen.height;
		ratio = Mathf.Clamp(ratio, 0.0f, 1.0f);
		float steer = (ratio - 0.5f) * 2.0f;
		return max * steer;
	}
}
