using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float amplitude = 1;          
    public float speed = 1;                  
    private float tempVal;
    private Vector3 tempPos;

    public bool doubleJ = false;
    public float Timer = 15;

    Movement movement;


    void Start()
    {
        movement = GameObject.FindObjectOfType<Movement>();

        tempPos = transform.position;
        tempVal = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //this makes the object move up and down
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = tempPos;

        //this makes the object rotate
        this.transform.Rotate(50 * Time.deltaTime, 0, 50 * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            StartCoroutine(power(other));
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

    }

    IEnumerator power(Collider other)
    {

        if (doubleJ)
        {

            movement.numJumps = 2;

            //states.doubleJump = true;
            //PS.enableEmission = false;
            //states.doublePS.enableEmission = true;
        }

        yield return new WaitForSeconds(Timer);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;

        if (doubleJ)
        {

            movement.numJumps = 1;

            //states.doublePS.enableEmission = false;
            //states.doubleJump = false;
            //PS.enableEmission = true;
        }
    }





}
