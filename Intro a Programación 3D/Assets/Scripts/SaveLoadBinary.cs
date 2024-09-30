using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveLoadBinary : MonoBehaviour
{
    public string fileName = "test.bin";
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

    void Save()
    {
        BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create));
        binaryWriter.Write(transform.position.x);
        binaryWriter.Write(transform.position.y);
        binaryWriter.Write(transform.position.z);
        binaryWriter.Flush();
        binaryWriter.Close();
    }

    void Load()
    {
        if (!File.Exists(fileName))
        {
            return;  
        }
        
        BinaryReader binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open));
        float x = binaryReader.ReadSingle();
        float y = binaryReader.ReadSingle();
        float z = binaryReader.ReadSingle();
        binaryReader.Close();

        transform.position = new Vector3(x, y, z);
    }
}
