using UnityEngine;

public class GateHeal: Gate {
	[Min(0)]
	[SerializeField] private float healingAmount;

	protected override void Action(Player player) {
		player.health.HealBy(healingAmount);
	}
}