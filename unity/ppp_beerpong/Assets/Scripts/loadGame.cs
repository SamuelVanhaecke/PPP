using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("2playergame");
        } else if (Input.GetKeyDown("e")) {
            SceneManager.LoadScene("4playergame");
        }
    }
}
