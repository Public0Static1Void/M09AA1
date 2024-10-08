using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    GameObject ob;
    private bool collided = true;
    void Start()
    {
        ob = TargetManager.tg.SpawnTarget();
        ob.transform.SetParent(transform);
        ob.transform.position = transform.position;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Respawn" && !collided)
        {
            collided = true;
            Destroy(ob);
            GameObject ob2 = TargetManager.tg.SpawnTargetBroken();
            ob2.transform.SetParent(transform);
            ob2.transform.position = transform.position;
            ob = ob2;
            StartCoroutine(wait_to_destroy());
        }
    }

    IEnumerator wait_to_destroy()
    {
        yield return new WaitForSeconds(Random.Range(5, 8));
        Destroy(ob);
        GameObject ob2 = TargetManager.tg.SpawnTarget();
        ob2.transform.SetParent(transform);
        ob2.transform.position = transform.position;
        ob = ob2;
        collided = false;
    }
}