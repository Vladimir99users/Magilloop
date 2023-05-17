using UnityEngine;
using DialogSystem;

public class NPCDialog : MonoBehaviour, ICanTalk
{
    [SerializeField] private Dialog _dialog;
    private GiveQuest _giveQuest => GetComponent<GiveQuest>();
    private void Start()
    {
        _dialog.ResetOptions();
        _dialog.Initialize();
    }
    public virtual void StartTalk()
    {
        _dialog.StartDialog();
        _giveQuest.SendMessageIntheWorld();
        _giveQuest.GiveQuestPlayer();

    }

}
