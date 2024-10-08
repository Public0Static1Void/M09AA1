using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] private GameObject ob_to_spawn;
    private bool collided = false;
    [SerializeField] private bool destroy;

    [SerializeField] private int score_gained;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Respawn" && !collided)
        {
            Debug.Log("Colision");

            if (destroy)
            {
                collided = true;

                GameObject ob = Instantiate(ob_to_spawn);
                ob.transform.position = transform.position;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;

                StartCoroutine(wait_to_destroy(ob));
            }
            else
                Destroy(other.gameObject);

            ScoreManager.scoreManager.IncreaseScore(score_gained);
        }
    }

    IEnumerator wait_to_destroy(GameObject ob)
    {
        yield return new WaitForSeconds(3);
        Destroy(ob);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        collided = false;
    }
}