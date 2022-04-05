using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTranslator : Translator, ITranslator
{
    void Start()
    {
        MovingObjects = GameObject.FindGameObjectsWithTag("Ground");
    }
    void Update()
    {
        Translate();
    }
}
