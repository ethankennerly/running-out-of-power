using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class RestartButton : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(Restart);
	}

	private void Restart()
	{
		SceneManager.LoadScene(0);
	}

}
