using UnityEngine;

public class Health : MonoBehaviour
{
    public bool Dead => _currentHealth <= 0f;
    public float MaxHealth => _characterData.maxHealth;
    public float CurrentHealth => _currentHealth;

    [SerializeField] private CharacterData  _characterData;

    private Animator  _animator;
    private float     _currentHealth;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _currentHealth = _characterData.maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        _currentHealth -= damage;
        _animator.Play("Get Hit");

        if (_currentHealth <= 0f)
            Die();
    }
    void Die()
    {
        _animator.SetTrigger("Dead");
    }
}
