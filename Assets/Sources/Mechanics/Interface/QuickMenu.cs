
using System.Collections.Generic;
using UI.Button.Conditional;
using UnityEngine;
using UnityEngine.Events;

namespace Mechanics.Interface
{
    public class QuickMenu : MonoBehaviour
    {

        public UI.Windows.WindowsGroupController windowsController;

        public ConditionalButton openPauseMenuButton;
        public ConditionalButton openQuestionsMenuButton;
        public ConditionalButton openGraphicsButton;
        public ConditionalButton openChatMenuButton;

        public enum OpenState
        {
            None, Pause, Questions, Statistics, Chat
        }

        [SerializeField]
        private OpenState m_OpenState = OpenState.None;
        public OpenState CurrentOpenState
        {
            get => m_OpenState;
            set
            {
                m_OpenState = value;
                switch (CurrentOpenState)
                {
                    case OpenState.None:
                        windowsController.CloseAllWindows();
                        break;
                    case OpenState.Pause:
                        windowsController.OpenWindow("QuickMenu.Pause");
                        break;
                    case OpenState.Questions:
                        windowsController.OpenWindow("QuickMenu.Questions");
                        break;
                    case OpenState.Statistics:
                        windowsController.OpenWindow("QuickMenu.Statistics");
                        break;
                    case OpenState.Chat:
                        windowsController.OpenWindow("QuickMenu.Chat");
                        break;
                    default:
                        break;
                }
            }
        }


        private void Start()
        {
            openPauseMenuButton.OnClick.AddListener(() => UpdateState(OpenState.Pause));
            openQuestionsMenuButton.OnClick.AddListener(() => UpdateState(OpenState.Questions));
            openGraphicsButton.OnClick.AddListener(() => UpdateState(OpenState.Statistics));
            openChatMenuButton.OnClick.AddListener(() => UpdateState(OpenState.Chat));

            UpdateState(m_OpenState);
        }

        public void UpdateState(OpenState state)
        {
            CurrentOpenState = state;
        }

        public void CloseAllWindows() => CurrentOpenState = OpenState.None;

    }
}
