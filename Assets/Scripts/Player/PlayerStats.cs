using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public DisplayDeathMessage deathMessage;
    [SerializeField] public float health = 100f;
    [SerializeField] public PlayerStatsGUI playerStatsGUI;
    [SerializeField] public MoveScene moveScene;

    [SerializeField] public PlayerMovement playerMovement;
    [SerializeField] public SoundController soundController;

    private bool isDead = false;
    private bool canPlayHurtSound = true;
    private float hurtSoundCooldown = 2.0f; 

    public void TakeDamage(float damage)
    {
        if (canPlayHurtSound)
        {
            soundController.PlayerHurtSound();
            canPlayHurtSound = false;
            StartCoroutine(HurtSoundCooldown());
        }
        health -= damage;
    }

    private IEnumerator HurtSoundCooldown()
    {
        yield return new WaitForSeconds(hurtSoundCooldown);
        canPlayHurtSound = true;
    }

    private void CheckDead()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            playerMovement.canMove = false;
            deathMessage.ShowDeathMessage();
            soundController.PlayerDeadSound();
            StartCoroutine(DeathRoutine());
        }
    }

    private IEnumerator DeathRoutine()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        playerMovement.canMove = true;
        deathMessage.HideDeathMessage();
        moveScene.Restart();
    }

    void Update()
    {
        playerStatsGUI.ShowHealth(health);
        CheckDead();
    }
}
