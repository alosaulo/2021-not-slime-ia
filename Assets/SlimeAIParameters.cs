using UnityEngine;
[System.Serializable]
public class SlimeAIParameters {
    [Header("Distance")]
    public float AtkMeleeDistance;
    public float AtkRangedDistance;
    public float ChaseDistance;
    [Header("Cooldown")]
    public float cooldownAtkRanged;
    public float cooldownAtkMelee;
    [HideInInspector]
    public bool doCooldownAtkRanged = false;
    [HideInInspector]
    public bool doCooldownAtkMelee = false;
}