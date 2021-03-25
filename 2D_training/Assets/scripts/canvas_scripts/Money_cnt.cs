using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money_cnt : MonoBehaviour
{
    static TextMeshProUGUI tmp;
    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "0";
    }
    public static void ChangeValue(int val)
    {
        tmp.text = (int.Parse(tmp.text) + val).ToString();
    }

    
}
