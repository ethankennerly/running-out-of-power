using UnityEngine;

[System.Serializable]
public sealed class Fin
{
	public GameObject parent;
	public Rigidbody2D body;
	public Rigidbody2D connectedBody;

	// Fin angular drag overwrites connected body angular drag.
	public void Setup()
	{
		body.gameObject.transform.SetParent(parent.transform, false);
		body.GetComponent<FixedJoint2D>().connectedBody = connectedBody;
		connectedBody.angularDrag = body.angularDrag;
	}
}
