using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesTranslator : Translator, ITranslator
{
    void Start()
    {
        MovingObjects = GameObject.FindGameObjectsWithTag("Forest");
    }
    void Update()
    {
        Translate();
    }
}
