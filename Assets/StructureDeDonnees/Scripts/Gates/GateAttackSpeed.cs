
using UnityEngine;

public class GateAttackSpeed: Gate {
	[Range(1, 3)]
	[SerializeField] private float attackCooldownDivider;

	protected override void Action(Player player) {
		player.laserCooldown /= attackCooldownDivider;

		if (player.laserCooldown < player.minAttackCooldown)
			player.laserCooldown = player.minAttackCooldown;
	}
}