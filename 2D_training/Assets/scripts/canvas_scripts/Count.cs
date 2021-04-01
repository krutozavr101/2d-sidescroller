using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Count : MonoBehaviour
{
    static TextMeshProUGUI tmp;
    [SerializeField]
    public int value;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "0";
    }
    public  void ChangeValue(int val)
    {
        tmp.text = (int.Parse(tmp.text) + val).ToString();
        value = int.Parse(tmp.text);
    }

    public void SetValue(int val)
    {
        tmp.text = tmp.text =  val.ToString();
        value = val;
    }


}
