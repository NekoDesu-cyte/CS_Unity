using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("References")]
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

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 1f;
    }
}
