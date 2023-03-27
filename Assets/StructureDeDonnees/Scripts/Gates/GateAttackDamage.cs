using UnityEngine;

public class GateAttackDamage: Gate {
	[SerializeField] private float bonusDamage;
	protected override void Action(Player player) {
		player.damage += bonusDamage;
	}
}