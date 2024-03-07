using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string nameSet;
    public int score;

    [SerializeField] GameObject Ui;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;

        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameScore();
        Debug.Log(nameSet + score);
    }

    [System.Serializable]
    class SaveData
        {
        public string Name;
        public int Score;

        }

    public void SaveNameScore(string name, int score)
    {
        SaveData data = new SaveData();
        data.Name = name;
        data.Score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadNameScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameSet = data.Name;
            score = data.Score;
            Ui.GetComponent<UiScript>().SetHighScore(nameSet, score);

        }

    }

    public void SetName(string name)
    {
        nameSet = name;
        Debug.Log(nameSet);
    }
    
}
