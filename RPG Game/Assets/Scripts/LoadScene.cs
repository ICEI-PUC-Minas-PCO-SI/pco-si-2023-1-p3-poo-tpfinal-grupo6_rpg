using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int id;
    float tempo;

    void Update()
    {
        tempo += Time.deltaTime;
        if(tempo>= 2)
            SceneManager.LoadScene(id);
    }
}
