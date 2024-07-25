using UnityEngine;

public class SaveSystemManager : MonoSingleton<SaveSystemManager>
{
    #region Private Fields

    private GameData    _gameData;
    private FileHandler _fileHandler;

    #endregion

    #region Init

    public override void Init()
    {
        _fileHandler = new FileHandler(Application.persistentDataPath, "GameData.save");
        LoadDataFromJsonFile();
    }

    #endregion

    #region Private Functions

    private void LoadDataFromJsonFile()
    {
        _gameData = _fileHandler.Load();

        if(_gameData == null)
        {
            Debug.Log("No GameData found. Initialize a new one.");
            _gameData = new GameData();
        }
    }

    private void SaveDataToJsonFile()
    {
        _fileHandler.Save(_gameData);
    }

    #endregion

    #region Public Functions

    /// <summary>
    /// This function will create and pass a deep copy of save data to 
    /// prevent the orignal data from being modified.
    /// </summary>
    /// <returns>The deep copy of the orignal save data.</returns>
    public GameData Load()
    {
        var copy = new GameData(_gameData);
        return copy;
    }

    public void Save(GameData data)
    {
        _gameData = data;
        SaveDataToJsonFile();
    }

    #endregion
}