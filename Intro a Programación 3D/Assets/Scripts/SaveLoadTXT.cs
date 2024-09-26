using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string fileName = "test.txt";
    // Start is called before the first frame update
    void Start()
    {
        
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
        //guardar
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + '\\' + fileName); //append true guarda los cambios y el append false sobresecribe esos cambios borrando los otros.
        streamWriter.WriteLine("Archivo de guardado");
        streamWriter.WriteLine(UnityEngine.Random.Range(0, 100));
        streamWriter.WriteLine(transform.position.x);
        streamWriter.WriteLine(transform.position.y);
        streamWriter.WriteLine(transform.position.z);

        streamWriter.Close();// cerrarlo para que los cambios de escritura se guarden.
    }
    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + '\\' + fileName))
            try
            {
                //cargar información
                StreamReader streamReader = new StreamReader(fileName);
                streamReader.ReadLine(); //la primera linea no es importante
                                         //movemos el cursor del archivo a la segunda linea.

                streamReader.ReadLine();
                float x = float.Parse(streamReader.ReadLine()); //Parse = pasar de un string a otro tipo. ej: pasar de string a float.
                float y = float.Parse(streamReader.ReadLine());
                float z = float.Parse(streamReader.ReadLine());

                streamReader.Close();

                transform.position = new Vector3(x, y, z); //establecemos la posicion del game object.
            }
            catch (System.Exception e) //como no guardamos info en ningun servidor.
                                       //GUARDAMOS EN LOCAL,  no tenemos control
                                       //sobre archivos de usuario. Nos aseguramos de que si algo va mal, esté todo controlado.
            {
                //sacar al topo de AC
                Debug.Log(e.Message);
            }
    }
  
}
