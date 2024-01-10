using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    
    public bool AttackTrue;

    public float attackDistance = 2.0f;
    public float followDistance = 10.0f;
    public float attackCooldown = 2.0f;
    public float attackTimer = 0.0f;
    public float attackDamage = 10.0f;

    Animator 動畫控制器;
    void Start()
    {
        動畫控制器 = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the follow distance
        if (distanceToPlayer <= followDistance)
        {
            // Set destination to the player's position
            enemy.SetDestination(player.position);

            if (AttackTrue == true){
                動畫控制器.SetFloat("Speed",1f);
            }
            
            // Check if the player is within the attack distance
            if (distanceToPlayer <= attackDistance)
            {
                // Check the attack cooldown before attacking again
                if (attackTimer <= 0.0f)
                {
                    // Attack the player
                    if(AttackTrue == true)
                        動畫控制器.SetBool("Attack",true);
                    AttackPlayer();
                    attackTimer = attackCooldown; // Reset the cooldown
                }
            }
            else 
                {
                    if(AttackTrue == true)
                        動畫控制器.SetBool("Attack",false);
                }
        }

        // Update the attack timer
        if (attackTimer > 0.0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void AttackPlayer()
    {
        // Add your attack logic here, such as dealing damage to the player
        Debug.Log("Attacking player! Dealing damage: " + attackDamage);

        // For example, you can reduce player health
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.collider.CompareTag("Player"))
        {

            enemy.velocity = Vector3.zero;
        }
    }
}