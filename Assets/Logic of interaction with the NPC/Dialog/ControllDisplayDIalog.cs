using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using DialogSystem.Item;
using UnityEngine;

namespace DialogSystem
{
    using Display;
   

    [RequireComponent(typeof(ViewDialog))]
    public class ControllDisplayDIalog : Menu
    {
        public static Action<Conversation> OnStartConfigurationDialog;
        private Dictionary<string,Node> _selectedPart;
        private readonly int STARTINDEX = 0;
        public event UnityAction<Node> OnEnteredNode;
        
        private void OnEnable()
        {
            OnStartConfigurationDialog += ConfigurationDialog;
           // OnCloseConfigurationDialog +=  Close;

            EventManadger.OnDialogEnd.AddListener(Close);
        }

        private void OnDisable()
        {
            OnStartConfigurationDialog -= ConfigurationDialog;
            //OnCloseConfigurationDialog -=  Close;
            EventManadger.OnDialogEnd.RemoveListener(Close);

        }
        private void ConfigurationDialog(Conversation anotherNode)
        {
            if(anotherNode is null) 
            {
                return;
            }

            _selectedPart = new Dictionary<string, Node>();
            foreach (var item in anotherNode.Nodes)
            {
                _selectedPart.Add(item.Contens.ToLower(),item);
            }

            Open();
            ChoseNextNode(anotherNode.Nodes[0].Contens.ToLower());
        }

        public void ChoseNextNode(string name)
        {
            OnEnteredNode?.Invoke(_selectedPart[name]);
        }




    }   
}

