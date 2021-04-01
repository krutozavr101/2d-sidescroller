using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;

public class Savable_object : MonoBehaviour
{
    [SerializeField]
    private string saveType;

    Save_Load_system manager;

    private void Awake()
    {
        manager = FindObjectOfType<Save_Load_system>();
        manager.objects.Add(this);
    }


    private void OnDestroy()
    {
        manager.objects.Remove(this);
    }
    public XElement GetElement()
    {
        XElement elem = null;


        if(saveType == "value")
        {
            XAttribute val = new XAttribute("val", GetComponent<Count>().value);

            elem = new XElement("value", name, val);
            return elem;
        }
        return elem;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}