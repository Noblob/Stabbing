using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabScript : MonoBehaviour
{

    public float damage = 1;
    public float range = 2f;
    public Camera Cam;
    public GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(StartStab());
            StartCoroutine(StartShot());
        }
    }

    IEnumerator StartStab()
    {
        Weapon.GetComponent<Animator>().Play("stab");
        yield return new WaitForSeconds(0.26f);
        Weapon.GetComponent<Animator>().Play("New State");
    }

    IEnumerator StartShot()
    {
        yield return new WaitForSeconds(0.1666f);
        ShootRaycast();
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log("Stabbed");
                target.TakeDamage(damage);
            }
        }
    }
}
