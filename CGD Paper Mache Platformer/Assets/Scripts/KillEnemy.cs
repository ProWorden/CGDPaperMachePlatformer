using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillEnemy : MonoBehaviour
{
    public CharacterController cc;
    private float enemyHeight = 0;
    public Movement playerScript;
    float KillTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.killEnemy)
        {
            KillTimer += Time.deltaTime;
            if(KillTimer >= 0.1f)
            {
                playerScript.killEnemy = false;
                KillTimer = 0;
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            enemyHeight = hit.gameObject.GetComponent<Renderer>().bounds.size.y;

            if ((hit.gameObject.transform.position.y + enemyHeight) <= transform.position.y)
            {
                Debug.Log("Kill Enemy");
                playerScript.killEnemy = true;
               
                playerScript.velocity.y = playerScript.jumpForce;
                Destroy(hit.gameObject);

            }
            else
            {
                Debug.Log("I Die");
            }
        }
    }
}
