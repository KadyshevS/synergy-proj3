using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _data;

    private InputMover _mover;
    private Attacker   _attacker;
    private Health     _health;

    void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _health = GetComponent<Health>();
        _mover = GetComponent<InputMover>();
    }
    void FixedUpdate()
    {
        if (_health.Dead) return;

        if (!_attacker.IsAttacking)
            _mover.Move();
    }
    void Update()
    {
        if (_health.Dead) return;

        if (Input.GetMouseButtonDown(0) && _attacker.CanAttack)
        {
            _attacker.Attack();
        }
    }
}
