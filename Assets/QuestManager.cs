using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour {

	public QuestLog questLog;

	private List<Quest> m_questPool = new List<Quest>();
	private List<Quest> m_activeQuests = new List<Quest>();

	void Awake() {
		m_questPool.Add (new Quest (Quest.Title.COMPLETE_1_LEVEL));
		m_questPool.Add (new Quest (Quest.Title.COMPLETE_2_LEVELS));
		m_questPool.Add (new Quest (Quest.Title.COMPLETE_3_LEVELS));
		m_questPool.Add (new Quest (Quest.Title.COMPLETE_4_LEVELS));
		m_questPool.Add (new Quest (Quest.Title.COMPLETE_5_LEVELS));
		m_questPool.Add (new Quest (Quest.Title.COLLECT_1_GOLD_MEDAL));
		m_questPool.Add (new Quest (Quest.Title.COLLECT_2_GOLD_MEDALS));
		m_questPool.Add (new Quest (Quest.Title.COLLECT_3_GOLD_MEDALS));
		m_questPool.Add (new Quest (Quest.Title.COLLECT_4_GOLD_MEDALS));
		m_questPool.Add (new Quest (Quest.Title.COLLECT_5_GOLD_MEDALS));

		List<int> randomIndices = new List<int> ();
		int questPoolCount = m_questPool.Count;
		for (int i = 0; i < questPoolCount; i++) {
			randomIndices.Add (i);
		}

		// TODO: choose 5 random quests from quest pool
		for (int i = 0; i < 5; i++) {
			int randomIndex = UnityEngine.Random.Range (0, randomIndices.Count);
			m_activeQuests.Add (m_questPool[randomIndices[randomIndex]]);
			questLog.AddQuestToLog (m_activeQuests [i]);
			randomIndices.RemoveAt (randomIndex);
		}
		questLog.SortQuestLog ();
	}

	public void SendQuestUpdateEvent(QuestUpdateEvent questUpdateEvent) {
		UpdateQuests (questUpdateEvent);
	}

	private void UpdateQuests(QuestUpdateEvent questEvent) {
		int activeQuestsCount = m_activeQuests.Count;
		for (int i = 0; i < activeQuestsCount; i++) {
			if (m_activeQuests [i].updateEvent == questEvent) {
				m_activeQuests [i].PushProgress ();
			}
		}
	}
}
