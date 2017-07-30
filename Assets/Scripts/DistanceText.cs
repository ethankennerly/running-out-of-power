using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class DistanceText : MonoBehaviour
{
	private Text text;

	private void Start()
	{
		text = GetComponent<Text>();
	}

	private void Update()
	{
		text.text = Main.instance.input.thruster.distance.ToString();
	}

}
