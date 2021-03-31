using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public delegate void MethodDelegate();
    [HideInInspector]
    public int curQuantity;
    protected List<MethodDelegate> delList = new List<MethodDelegate>();

    protected IEnumerator EmergencyDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(8);
        if (obj != null)
        {
            Destroy(obj);
            curQuantity--;

        }
    }
    protected IEnumerator SpawnRandomObject(int objTypeCnt)
    {


        curQuantity++;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        delList[objTypeCnt]();
    }
}
