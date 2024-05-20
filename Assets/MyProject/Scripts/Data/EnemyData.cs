using UnityEngine;

[CreateAssetMenu(menuName = "Config/Enemy", fileName = "NewEnemyData")]
public class EnemyData : CharacterData
{
  public float   distanceToFollow;
  public float   distanceToAttack;
  public float   idleBetweenPoints;
}