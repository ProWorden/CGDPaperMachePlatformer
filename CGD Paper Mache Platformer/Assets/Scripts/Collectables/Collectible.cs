using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private GameHandler GH;

    private float tempVal;
    private Vector3 tempPos;
    private float amplitude = 0.25f;
    private float speed = 1f;
    public ParticleSystem PS;
   // public float Timer = 15;


    // Start is called before the first frame update
    void Start()
    {
        GH = GameObject.Find("Canvas").GetComponent<GameHandler>();
       tempPos = transform.position;
        tempVal = transform.position.y;
        PS.enableEmission = false;

    }

    // Update is called once per frame
    void Update()
    {
         //this makes the object move up and down
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = tempPos;

        //this makes the object rotate
        this.transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        /* GH.collectable++;
         Destroy(gameObject);*/

        StartCoroutine(collectible(other));

    }



    IEnumerator collectible(Collider other)
    {
        GH.collectable++;
        PS.enableEmission = true;
        yield return new WaitForSeconds(1);

        //PS.Clear ;

        Destroy(gameObject); 

    }
}
