using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class ActivateButton : MonoBehaviour
{
	public GameObject target;
	public bool isActivate = true;

	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(Activate);
	}

	private void Activate()
	{
		target.SetActive(isActivate);
	}

}
