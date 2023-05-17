using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DialogSystem
{
    using Item;

    [CreateAssetMenu(fileName = "Dialog", menuName = "Conversation/Dialog/dialog")]
    public class Dialog : ScriptableObject
    {
        [Header("Последовательность диалогов")]
        [SerializeField] private  List<LocalizationTextFile<Conversation>> _conversation ;
        [SerializeField]private CreateNewNPC _nameNPC;
        public int IDConversation {get; set;}
        public bool IsStart {get; set;}
        private void OnDisable()
        {
            Debug.Log("Disable Dialog");
            EventManadger.OnChangeConversation.RemoveAllListeners();
        }
        public void ResetOptions()
        {
            IsStart = false;
        }
        public virtual void Initialize()
        {
            if(IsStart == false)
            {
                IDConversation = 0;
                IsStart = true;
                EventManadger.OnChangeConversation.AddListener(ChangeConversation);
            }
        }
        public virtual void ChangeConversation(CreateNewNPC NPCWichTalk)
        {
            if(_nameNPC.Name == NPCWichTalk.Name)
            {
                NextConversation();
            }
        }
        public void NextConversation()
        {
            IDConversation = IDConversation + 1;
        }
        public virtual void StartDialog()
        {
            if(IDConversation < _conversation.Count)
            {
                StartСonversation(IDConversation);
            }
        }
        private void StartСonversation(int index)
        {
            ControllDisplayDIalog.OnStartConfigurationDialog?.Invoke(_conversation[index].GetText());     
        }
    }

}
