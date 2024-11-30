using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Character", menuName = "Swipe Objects/Character")]
public class Character : ScriptableObject
{
    public int health;
    public float Speed;
    public int ScoreCost;
}
