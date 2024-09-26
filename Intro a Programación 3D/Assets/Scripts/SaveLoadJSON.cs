using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]//UN OBJETO QUE ES CAPAZ DE CONVERTIRSE A UN ARCHIVO EN FORMATO JSON Y ADEMAS CONVERTIR EL ARCHIVO AL OBJETO SE DENOMINA COMO OBJETO SERIALIZABLE
struct PlayerData
{
    public Vector3 position; 
}

public class SaveLoadJSON : MonoBehaviour
{
    public string fileName = "test.json";
    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + '\\' + fileName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        StreamWriter streamWriter = new StreamWriter(fileName);

        PlayerData playerData = new PlayerData(); //INSTANCIO EL OBJETO QUE VAMOS A GUARDAR
        playerData.position = transform.position; //Rellenamos de info

        string json = JsonUtility.ToJson(playerData);//ToJson recibe un objeto serializable y genera el string en formato Json
        streamWriter.Write(json);


        streamWriter.Close();
    }
    private void Load()
    {
        if (File.Exists(fileName))
        {
            
            StreamReader streamReader = new StreamReader(fileName);

            string json = streamReader.ReadToEnd();
            streamReader.Close();

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json); //"FromJson" = De Json a objeto. Leemos todo hasta el final. Te devuelve en formato Json

                transform.position = playerData.position;
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message); //sacar al topo de AC
            }
        }
    }
}
