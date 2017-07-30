using UnityEngine;

[System.Serializable]
public sealed class Nose
{
	public GameObject parent;
	public Rigidbody2D body;
	public Rigidbody2D connectedBody;

	// Nose drag overwrites connected body drag.
	public void Setup()
	{
		body.gameObject.transform.SetParent(parent.transform, false);
		body.GetComponent<FixedJoint2D>().connectedBody = connectedBody;
		connectedBody.drag = body.drag;
	}
}
