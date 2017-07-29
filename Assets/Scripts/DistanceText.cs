using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class DistanceText : MonoBehaviour
{
	public Transform mover;
	private Text text;

	private void Start()
	{
		text = GetComponent<Text>();
	}

	private void Update()
	{
		text.text = mover.position.x.ToString("N0");
	}

}
