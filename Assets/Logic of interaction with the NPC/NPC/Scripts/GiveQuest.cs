using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GiveQuest : MonoBehaviour
{
    [SerializeField] protected  Quest.Quest _quest;
    [SerializeField] protected NameNPC _npc => GetComponent<NameNPC>();

    private void Start()
    {
        if(_quest != null)
        {
            _quest.WhoIssuedQuestNPC = _npc.NPC;
            Debug.Log("Инизиализация прошла успешно у " + _quest.WhoIssuedQuestNPC);
        }
    }
    public abstract void SendMessageIntheWorld();

    public abstract void GiveQuestPlayer();
}
