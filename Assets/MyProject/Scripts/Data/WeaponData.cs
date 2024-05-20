using UnityEngine;

[CreateAssetMenu(menuName = "Config/Weapon", fileName = "NewWeaponData")]
public class WeaponData : ScriptableObject
{
  public float        damage;
  public float        attackColldown;
  public float        attackDuration;
  public float        attackRange;
  public Vector3      attackRangeOffset;
  public GameObject   prefab;
}