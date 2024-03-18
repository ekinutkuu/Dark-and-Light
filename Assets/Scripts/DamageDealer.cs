using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] float weaponLenght;
    [SerializeField] float weaponDamage;

    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << LayerMask.NameToLayer("Enemy");

            if( Physics.Raycast(transform.position, -transform.up, out hit, weaponLenght, layerMask) )
            {
                if (!hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    print("damage");
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }

        }
    }
    
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
        //print("start");
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
        //print("end");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLenght);
    }

}
