using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Playerwepon : MonoBehaviour
{

    public GameObject bulletprefs;
    public Transform bulletspwan;
    public float bulletspeed = 30;
    public float Lifetime = 3;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletprefs);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),bulletspwan.parent.GetComponent<Collider>());
        bullet.transform.position = bulletspwan.position;
        Vector3 rotation = bullet.transform .rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x,transform.eulerAngles.y, rotation.z);
        bullet.GetComponent<Rigidbody>().AddForce(bulletspwan.forward * bulletspeed, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, Lifetime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject Bullet,float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(Bullet);
    }

   
}
