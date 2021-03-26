using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public delegate void MethodDelegate();
    public int curQuantity;
    protected List<MethodDelegate> delList = new List<MethodDelegate>();

    protected IEnumerator EmergencyDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        if (obj != null)
        {
            Destroy(obj);
            curQuantity--;

        }
    }
    protected IEnumerator SpawnRandomObject(int objTypeCnt)
    {
        print(transform.position);

        curQuantity++;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        delList[objTypeCnt]();
    }
}
