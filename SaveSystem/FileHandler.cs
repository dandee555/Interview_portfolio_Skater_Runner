using UnityEngine;
using System;
using System.IO;

public class FileHandler
{
    #region Private Fields

    private string _fileDirPath;
    private string _fileName;

    #endregion

    #region Constructor

    public FileHandler(string fileDirPath, string fileName)
    {
        _fileDirPath = fileDirPath;
        _fileName    = fileName;
    }

    #endregion

    #region Public Functions

    public void Save(GameData data)
    {
        //Different operating systems have different path separators.
        string fullPath = Path.Combine(_fileDirPath, _fileName);

        try
        {
            _ = Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToSave = JsonUtility.ToJson(data, true);

            using var stream = new FileStream(fullPath, FileMode.Create);
            using var writer = new StreamWriter(stream);
            writer.Write(dataToSave);
        }
        catch(Exception e)
        {

            Debug.LogError($"Error occured when trying to save data.\nPath : {fullPath}.");
            throw new Exception(e.Message);
        }
    }

    public GameData Load()
    {
        //Different operating systems have different path separators.
        string fullPath = Path.Combine(_fileDirPath, _fileName);

        GameData loadedData = null;

        if(File.Exists(fullPath))
        {
            try
            {
                using var stream    = new FileStream(fullPath, FileMode.Open);
                using var reader    = new StreamReader(stream);
                string dataFromFile = reader.ReadToEnd();

                loadedData = JsonUtility.FromJson<GameData>(dataFromFile);
            }
            catch(Exception e)
            {
                Debug.LogError($"Error occured when trying to load data.\nPath : {fullPath}.");
                throw new Exception(e.Message);
            }
        }

        return loadedData;
    }

    #endregion
}
