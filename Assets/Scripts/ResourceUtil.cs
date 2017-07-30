using UnityEngine;

public sealed class ResourceUtil
{
	public static bool isVerbose = true;

	// parent:  Expects exactly one child.
	// prefab:  If null, return child.
	public static GameObject ReplaceChild(GameObject parent, string prefab)
	{
		GameObject child = parent.transform.GetChild(0).gameObject;
		if (System.String.IsNullOrEmpty(prefab))
		{
			return child;
		}
		if (isVerbose)
		{
			Debug.Log("ResourceUtil.ReplaceChild: " + parent.name + " prefab " + prefab);
		}
		GameObject replacement = (GameObject)GameObject.Instantiate(Resources.Load(prefab));
		GameObject.Destroy(child);
		replacement.transform.SetParent(parent.transform, false);
		return replacement;
	}
}
