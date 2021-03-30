using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    float fireRate = .4f;
    // Start is called before the first frame update

    private void OnEnable()
    {
        InvokeRepeating("ShootBullet", 0, fireRate);

    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position - new Vector3(0, 4, 0), Quaternion.identity);
        Destroy(bullet, 3);
    }
}
