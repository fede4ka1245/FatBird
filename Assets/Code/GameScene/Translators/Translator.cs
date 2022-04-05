using UnityEngine;

public abstract class Translator : MonoBehaviour, ITranslator
{
    [SerializeField]
    protected GameObject[] MovingObjects;
    protected float Speed;
    protected Game game;

    protected void Awake()
    {
        game = FindObjectOfType<Game>();
        Speed = game.Speed;
    }

    public void Translate()
    {
        for (int index = 0; index < MovingObjects.Length; index++)
        {
            MovingObjects[index].transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
    }
}
