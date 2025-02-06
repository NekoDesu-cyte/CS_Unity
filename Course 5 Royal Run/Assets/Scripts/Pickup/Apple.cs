using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmmount = 2f;

    LevelGenerator levelGenerator;

    void Start() 
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSPeed(adjustChangeMoveSpeedAmmount);
        Debug.Log("POWER UP!!!!");
    }
}
