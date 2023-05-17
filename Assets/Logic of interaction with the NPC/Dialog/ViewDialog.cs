using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using DialogSystem.Item;

namespace DialogSystem.Display
{
    
    public class ViewDialog : MonoBehaviour
    {
        [Header("Компоненты для визуального отображения диалога")]
        [SerializeField] private TextMeshProUGUI _dialogTextMeshPro;
        [SerializeField] private Button _prefabsButton;
        [SerializeField] private RectTransform _positionOfResponses;

        private ControllDisplayDIalog _controller => GetComponent<ControllDisplayDIalog>();


        private void OnEnable()
        {
            _controller.OnEnteredNode += ViewNodes;
        }
        private void OnDisable()
        {
            _controller.OnEnteredNode -= ViewNodes;
        }

        private void ViewNodes(Node _currentNode)
        {

            DeleteAllChild(_positionOfResponses);
            StopAllCoroutines();

            _dialogTextMeshPro.text = _currentNode.MainText;
            if(_currentNode.Responce.Length != 0)
            {
                for(int i = _currentNode.Responce.Length - 2; i >= 0; i--)
                {
                    Button button = Instantiate(_prefabsButton,_positionOfResponses) as Button;
                    var passage = _currentNode.Responce[i];
                    button.GetComponentInChildren<TextMeshProUGUI>().text = passage.Name;
                    button.onClick.AddListener(delegate { _controller.ChoseNextNode(passage.Id.ToLower()); });
                }
            } else 
            {
                EventManadger.SendAboutDialogueHasEnded();
            }
            
        }
        private void DeleteAllChild(RectTransform parent)
        {
            UnityEngine.Assertions.Assert.IsNotNull(parent);
            for (int children = parent.childCount - 1; children >= 0; children--)
            {
                Destroy(parent.GetChild(children).gameObject);
            }
        }

    }
}
