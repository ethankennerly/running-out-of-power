using System.Collections.Generic;
using UnityEngine;

public sealed class ActivateOnStart : MonoBehaviour
{
	public List<GameObject> activates;
	public List<GameObject> deactivates;

	private void Start()
	{
		for (int index = 0, end = activates.Count; index < end; ++index)
		{
			activates[index].SetActive(true);
		}
		for (int index = 0, end = deactivates.Count; index < end; ++index)
		{
			deactivates[index].SetActive(false);
		}
	}
}
