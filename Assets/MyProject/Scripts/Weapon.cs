using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _data;

    public float        Damage              { get {return _data.damage;} }
    public float        AttackCooldown      { get {return _data.attackColldown;} }
    public float        AttackDuration      { get {return _data.attackDuration;} }
    public float        AttackRange         { get {return _data.attackRange;} }
    public Vector3      AttackRangeOffset   { get {return _data.attackRangeOffset;} }
    public GameObject   Prefab              { get {return _data.prefab;} }
}
