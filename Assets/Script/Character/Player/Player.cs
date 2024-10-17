using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure to include the UI namespace

public class Player : Character
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    private GameObject healthBarCanvas;  // Canvas to hold the health bar
    private Image healthBarImage;        // Health bar image
    private RectTransform healthBarRectTransform;

    [Header("Melee Attack")]
    public float meleeAttackDamage;
    public Vector2 attackSize = new Vector2(1f, 1f);
    public float offsetX = 1f;
    public float offsetY = 1f;

    public LayerMask enemyLayer;

    private Vector2 AttackAreaPos;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;

        // Create health bar canvas and UI elements dynamically
        CreateHealthBar();
        UpdateHealthBar(); // Initialize health bar

        // Additional initialization if needed
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MeleeAttackAnimEvent(float isAttack)
    {
        AttackAreaPos = (Vector2)transform.position;

        offsetX = spriteRenderer.flipX ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f, enemyLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage * isAttack);
            hitCollider.GetComponent<EnemyController>().Knockback(transform.position);
        }
    }

    // Dynamically create a health bar
    private void CreateHealthBar()
    {
        healthBarCanvas = new GameObject("HealthBarCanvas");
        Canvas canvas = healthBarCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        CanvasScaler canvasScaler = healthBarCanvas.AddComponent<CanvasScaler>();
        canvasScaler.dynamicPixelsPerUnit = 100f;
        healthBarCanvas.AddComponent<GraphicRaycaster>();

        GameObject healthBarBackground = new GameObject("HealthBarBackground");
        healthBarBackground.transform.SetParent(healthBarCanvas.transform, false);
        Image backgroundImage = healthBarBackground.AddComponent<Image>();
        backgroundImage.color = Color.red;

        GameObject healthBar = new GameObject("HealthBar");
        healthBar.transform.SetParent(healthBarBackground.transform, false);
        healthBarImage = healthBar.AddComponent<Image>();
        healthBarImage.color = Color.green;

        healthBarRectTransform = healthBar.GetComponent<RectTransform>();
        RectTransform bgRectTransform = healthBarBackground.GetComponent<RectTransform>();

        // Reduce the size of the health bar
        bgRectTransform.sizeDelta = new Vector2(0.7f, 0.07f); // Reduced from 1f, 0.1f
        healthBarRectTransform.sizeDelta = bgRectTransform.sizeDelta;

        healthBarCanvas.transform.SetParent(transform, false);
        healthBarCanvas.transform.localPosition = new Vector3(0, 0.2f, 0);
        
        // Reduce the overall scale of the health bar
        healthBarCanvas.transform.localScale = new Vector3(0.7f, 0.7f, 1);
    }

    // Update health bar fill based on current health
    private void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBarRectTransform.localScale = new Vector3(healthPercentage, 1f, 1f);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Update the health bar when taking damage
        UpdateHealthBar();
    }

    //for testing
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(AttackAreaPos, attackSize);
    }
}
