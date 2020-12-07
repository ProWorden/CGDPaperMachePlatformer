using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public Text collectableText;
    public int collectable = 0;

    // Update is called once per frame
    void Update()
    {
        collectableText.text = " " + collectable;

    
      

    }





}
