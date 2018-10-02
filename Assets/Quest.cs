using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Quest {

	public enum Title { COMPLETE_1_LEVEL, COMPLETE_2_LEVELS, COMPLETE_3_LEVELS, COMPLETE_4_LEVELS, COMPLETE_5_LEVELS,
						COLLECT_1_GOLD_MEDAL, COLLECT_2_GOLD_MEDALS, COLLECT_3_GOLD_MEDALS, COLLECT_4_GOLD_MEDALS, COLLECT_5_GOLD_MEDALS }
	
	public Text questText { private get; set;}
	public QuestUpdateEvent updateEvent { get; private set;}
	private bool m_completed;
	private Title m_title;
	public string m_description { get; private set;}
	private int m_currentProgress;
	private int m_goal {get;set;}


	public Quest(Title title) {
		m_completed = false;
		m_title = title;
		Initialize ();
	}

	public void PushProgress() {
		if (!m_completed) {
			m_currentProgress++;
			ShowProgress ();
			CheckProgress ();
		}
	}

	public void ShowProgress() {
		if (questText != null) {
			questText.text = string.Concat (m_description, ": ");
			questText.text = string.Concat (questText.text, m_currentProgress.ToString());
			questText.text = string.Concat (questText.text, "/");
			questText.text = string.Concat (questText.text, m_goal.ToString());
		}
	}

	private void CheckProgress() {
		if (m_currentProgress == m_goal) {
			m_completed = true;
			questText.color = Color.green;
		}
	}

	private void Initialize() {
		switch (m_title) {
		case Title.COMPLETE_1_LEVEL:
			m_description = "Complete your first level";
			m_goal = 1;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.LEVEL_COMPLETED;
			break;
		case Title.COMPLETE_2_LEVELS:
			m_description = "Complete 2 Levels";
			m_goal = 2;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.LEVEL_COMPLETED;
			break;
		case Title.COMPLETE_3_LEVELS:
			m_description = "Complete 3 Levels";
			m_goal = 3;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.LEVEL_COMPLETED;
			break;
		case Title.COMPLETE_4_LEVELS:
			m_description = "Complete 4 Levels";
			m_goal = 4;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.LEVEL_COMPLETED;
			break;
		case Title.COMPLETE_5_LEVELS:
			m_description = "Complete 5 Levels";
			m_goal = 5;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.LEVEL_COMPLETED;
			break;
		case Title.COLLECT_1_GOLD_MEDAL:
			m_description = "Collect 1 gold medal";
			m_goal = 1;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.GOLD_MEDAL_COLLECTED;
			break;
		case Title.COLLECT_2_GOLD_MEDALS:
			m_description = "Collect 2 gold medals";
			m_goal = 2;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.GOLD_MEDAL_COLLECTED;
			break;
		case Title.COLLECT_3_GOLD_MEDALS:
			m_description = "Collect 3 gold medals";
			m_goal = 3;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.GOLD_MEDAL_COLLECTED;
			break;
		case Title.COLLECT_4_GOLD_MEDALS:
			m_description = "Collect 4 gold medals";
			m_goal = 4;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.GOLD_MEDAL_COLLECTED;
			break;
		case Title.COLLECT_5_GOLD_MEDALS:
			m_description = "Collect 5 gold medals";
			m_goal = 5;
			m_currentProgress = 0;
			updateEvent = QuestUpdateEvent.GOLD_MEDAL_COLLECTED;
			break;
		}
	}
}
