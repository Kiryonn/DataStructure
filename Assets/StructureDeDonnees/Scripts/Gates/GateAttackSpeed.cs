
using UnityEngine;

public class GateAttackSpeed: Gate {
	[Range(0, 0.5f)]
	[SerializeField] private float attackCooldownBuff;

	protected override void Action(Player player) {
		player.laserCooldown -= attackCooldownBuff;

		if (player.laserCooldown < player.minAttackCooldown)
			player.laserCooldown = player.minAttackCooldown;
	}
}