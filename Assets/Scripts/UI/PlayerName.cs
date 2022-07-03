using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public static PlayerName Instance;
	 public string PName = "";

	 private void Awake()
    {
		if (Instance != null)
    	{
			Destroy(gameObject);
			return;
    	}

		Instance = this;
      DontDestroyOnLoad(gameObject);
    }
}