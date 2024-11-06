using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveNLoad : MonoBehaviour
{
     Coin coins;
    private void Awake()
    {
        coins=GameObject.FindAnyObjectByType<Coin>();
        Load();
    }
    // Start is called before the first frame update
    public void Save()
    {
        Debug.Log("Saved!");
        FileStream file=new FileStream(Application.persistentDataPath+"/Player.dat",FileMode.OpenOrCreate);
        try
        {
            BinaryFormatter formatter=new BinaryFormatter();
            formatter.Serialize(file,coins.InfoToSave);
        }
        catch(SerializationException e)
        {
            Debug.LogError("There was an issue in save:"+e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    // Update is called once per frame
    void Load()
    {
        FileStream file= new FileStream(Application.persistentDataPath+"/Player.dat",FileMode.Open);
        try
        {
             BinaryFormatter formatter=new BinaryFormatter();
            coins.InfoToSave=(SaveInfo)formatter.Deserialize(file);
        }
        catch(SerializationException e)
        {
            Debug.LogError("There was an issue in Load:"+e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void ClearData()
{
    string path = Application.persistentDataPath + "/Player.dat";
    
    if (File.Exists(path))
    {
        File.Delete(path);
        Debug.Log("Data cleared!");
    }
    else
    {
        Debug.LogWarning("No data file found to delete.");
    }
}
}
