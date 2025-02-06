using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmmount = -2f;

    LevelGenerator levelGenerator;

    void Start() 
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    float cooldownTimer = 0f;
    const string hitString = "Hit";

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other) 
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSPeed(adjustChangeMoveSpeedAmmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}
