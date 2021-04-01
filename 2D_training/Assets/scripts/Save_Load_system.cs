using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;
using UnityEngine.SceneManagement;
public class Save_Load_system : MonoBehaviour
{

    [HideInInspector]
    public List<Savable_object> objects = new List<Savable_object>(); 
    private string path;
    private void Awake()
    {
        
        path = Application.persistentDataPath + "/xdoc.saveFile";
        SceneManager.sceneLoaded += Load;
    }


 
    public void Save()
    {
        XElement root = new XElement("root");
        foreach (Savable_object obj in objects)
        {
            root.Add(obj.GetElement());
            print(obj.GetElement());
        }
        XDocument xdoc = new XDocument(root);
        File.WriteAllText(path, xdoc.ToString());
    }

    public void Load(Scene scene, LoadSceneMode mode)
    {
        XElement root = null;
        if (!(File.Exists(path)))
        {
            if (File.Exists(Application.persistentDataPath + "/DefaultLayout.saveFile"))
            {
                root = XDocument.Parse(File.ReadAllText(Application.persistentDataPath + "/DefaultLayout.saveFile")).Element("root");
            }
        }
        else
        root = XDocument.Parse(File.ReadAllText(path)).Element("root");
        GenerateScene(root);
    }

    private void GenerateScene(XElement root)
    {

            foreach (XElement value in root.Elements("value"))
            {
                GameObject obj = GameObject.Find(value.Value);
                print(obj);
                obj.GetComponent<Count>().SetValue(int.Parse(value.Attribute("val").Value));
            }
        

    }
    private void OnApplicationQuit()
    {
        Save();
    }
}


