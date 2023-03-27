using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "StructureDeDonnees/GameData")]
public class GameData: ScriptableObject
{
	public List<LevelData> levels;
}
