using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour {

	public Text quest1;
	public Text quest2;
	public Text quest3;
	public Text quest4;
	public Text quest5;

	private List<Quest> m_quests = new List<Quest>();
	private List<Text> m_questTexts = new List<Text>();

	void Awake() {
		m_questTexts.Add (quest1);
		m_questTexts.Add (quest2);
		m_questTexts.Add (quest3);
		m_questTexts.Add (quest4);
		m_questTexts.Add (quest5);
	}

	public void AddQuestToLog(Quest quest) {
		if (m_quests == null) {
			Debug.Log ("Quests null!");
		}
		if (!m_quests.Contains (quest) && m_quests.Count < 5) {			
			
			quest.ShowProgress ();
			m_quests.Add (quest);

		} else {
			if (m_quests.Contains (quest)) {
				Debug.LogError ("Quest is already in quest log!");
			} else {
				Debug.LogError ("Quest log cannot hold more than 5 quests!");
			}
		}
	}

	public void SortQuestLog() {
		m_quests.Sort (delegate(Quest x, Quest y) {
			return x.m_description.CompareTo(y.m_description);
		});
		int questsCount = m_quests.Count;
		for (int i = 0; i < questsCount; i++) {
			m_quests [i].questText = m_questTexts [i];
			m_quests [i].ShowProgress ();
		}
	}
}
