using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static BestScore Instance;
    public int Score = 0;
    public string BestScoreName = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadScore();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class SaveData
    {
        public int Score;
        public string BestScoreName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData
        {
            Score = Score,
            BestScoreName = BestScoreName
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Score = data.Score;
            BestScoreName = data.BestScoreName;
        }
    }
}
