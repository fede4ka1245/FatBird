using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    IBird bird;

    private void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<IBird>();
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        bird.Jump();
    //}

    public void OnScreenClick()
    {
        bird.Jump();
    }
}
