using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTranslator : Translator, ITranslator
{
    void Start()
    {
        MovingObjects = GameObject.FindGameObjectsWithTag("Cloud");
        Speed = Speed / 2;
    }

    private void Update()
    {
        Translate();
    }
}
