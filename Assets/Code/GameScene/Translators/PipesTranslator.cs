using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesTranslator : Translator, ITranslator
{
    void Start()
    {
        MovingObjects = GameObject.FindGameObjectsWithTag("Pipes");
    }
    void Update()
    {
        Translate();
    }
}
