using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance {
        get; private set;
    }

    public SaveData Data {
        get; private set;
    }

    private string savePath;

    void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Path.Combine(Application.persistentDataPath, "save.json");

        LoadGame();
    }

    void LoadGame() {
        if(!File.Exists(savePath)) {
            Data = new SaveData();
            SaveGame();
            return;
        }

        string json = File.ReadAllText(savePath);
        Data = JsonUtility.FromJson<SaveData>(json);
    }

    void SaveGame() {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(savePath, json);
    }

    public void CompleteNight(int night) {
        if(night <= Data.highestNight)
            return;

        Data.highestNight = night;
        SaveGame();
    }
}