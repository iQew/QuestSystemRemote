using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

	public QuestManager questManager;

	public void CompleteLevel() {
		questManager.SendQuestUpdateEvent (QuestUpdateEvent.LEVEL_COMPLETED);
	}

	public void CollectGoldMedal() {
		questManager.SendQuestUpdateEvent (QuestUpdateEvent.GOLD_MEDAL_COLLECTED);
	}

}
