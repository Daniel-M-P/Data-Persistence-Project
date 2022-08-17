using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    public class PlayerData
    {
        public int bestScore = 0;
        public string playerName;
    }

    public PlayerData pData = new PlayerData();

    public void SaveData()
    {
        string json = JsonUtility.ToJson(pData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            pData.playerName = data.playerName;
            pData.bestScore = data.bestScore;
        }
    }
}
