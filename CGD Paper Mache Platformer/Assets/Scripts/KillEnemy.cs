using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillEnemy : MonoBehaviour
{
    public CharacterController cc;
    private float enemyHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
           
            if ((hit.gameObject.transform.position.y + enemyHeight) <= transform.position.y)
            {
                Debug.Log("Poo");
            }
        }
    }
}
