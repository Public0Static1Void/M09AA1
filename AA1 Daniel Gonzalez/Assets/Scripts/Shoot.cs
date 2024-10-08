using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float recoil;
    [SerializeField] private float force;
    private bool shooting;

    void Update()
    {
        if (!shooting && Input.GetKeyDown(KeyCode.Space))
            ShootBullet();
    }

    void ShootBullet()
    {
        StartCoroutine(wait_to_shoot());
        GameObject bull = Instantiate(bullet);
        
        bull.transform.position = transform.position;

        bull.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        bull.transform.rotation = transform.parent.transform.rotation;

        StartCoroutine(wait_to_die(bull));
    }

    private IEnumerator wait_to_shoot()
    {
        shooting = true;
        yield return new WaitForSeconds(recoil);
        shooting = false;
    }

    private IEnumerator wait_to_die(GameObject ob)
    {
        yield return new WaitForSeconds(5);
        Destroy(ob);
    }
}