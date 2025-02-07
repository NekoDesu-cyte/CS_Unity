using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmmount = 2f;

    LevelGenerator levelGenerator;

    public void init(LevelGenerator levelGenerator) 
    {
        this.levelGenerator = levelGenerator;
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmmount);
        Debug.Log("POWER UP!!!!");
    }
}
