using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager tg {  get; private set; }
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject target_broken;
    // Start is called before the first frame update
    void Awake()
    {
        if (tg == null)
            tg = this;
        else
            Destroy(this.gameObject);
    }

    public GameObject SpawnTarget()
    {
        return Instantiate(target);
    }
    public GameObject SpawnTargetBroken()
    {
        return Instantiate(target_broken);
    }
}