using UnityEngine;

public class Attacker : MonoBehaviour
{
    public bool CanAttack => _attackTimer <= 0f;
    public bool IsAttacking => _attackingTimer > 0f;
    public bool MaskInRange =>
        Physics.CheckSphere(
            transform.position + 
            transform.forward.normalized * _weapon.AttackRangeOffset.z +
            transform.up.normalized * _weapon.AttackRangeOffset.y +
            transform.right.normalized * _weapon.AttackRangeOffset.x, 
            _weapon.AttackRange, _attackMask);

    [SerializeField] private Animator   _animator; 
    [SerializeField] private LayerMask  _attackMask;
    [SerializeField] private Weapon     _weapon;
    [SerializeField] private GameObject _hand;

    private int        _attackIndex;
    private float      _attackTimer;
    private float      _attackingTimer;
    private Collider[] _hits;

    private void ResetAttackTimer() => _attackTimer = _weapon.AttackCooldown;
    private void ResetAttackingTimer() => _attackingTimer = _weapon.AttackDuration * (_attackIndex + 1f);

    void Start()
    {
        ResetAttackTimer();
        _hits = new Collider[3];

        var pref = _weapon.Prefab;
        Instantiate(pref, _hand.transform);
    }
    void Update()
    {
        _attackTimer -= Time.deltaTime;
        _attackingTimer -= Time.deltaTime;

        if (_attackingTimer > 0f)
            _animator.SetTrigger("Attacking");
        else
            _animator.SetBool("Attacking", false);
    }
    
    public void Attack()
    {
        if (_attackingTimer <= 0f)
        {
            _attackIndex = Random.Range(0, 2);
            _animator.SetInteger("AttackIndex", _attackIndex);
            ResetAttackTimer();
            ResetAttackingTimer();
            AttackEnemies();
        }
    }

    void AttackEnemies()
    {
        Physics.OverlapSphereNonAlloc(
            transform.position + 
            transform.forward.normalized * _weapon.AttackRangeOffset.z +
            transform.up.normalized * _weapon.AttackRangeOffset.y +
            transform.right.normalized * _weapon.AttackRangeOffset.x, 
            _weapon.AttackRange, _hits, _attackMask);

        for (int i = 0; i < _hits.Length; i++)
        {
            if (!_hits[i]) break;
            if (_hits[i].TryGetComponent(out Health health))
            {
                health.TakeDamage(_weapon.Damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position + 
            transform.forward.normalized * _weapon.AttackRangeOffset.z +
            transform.up.normalized * _weapon.AttackRangeOffset.y +
            transform.right.normalized * _weapon.AttackRangeOffset.x, 
            _weapon.AttackRange);
    }
}
