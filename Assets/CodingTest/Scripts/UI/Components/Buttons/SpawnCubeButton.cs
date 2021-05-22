using Zenject;

namespace CodingTest.Scripts.UI.Components.Buttons
{
    public class SpawnCubeButton : ButtonComponent
    {

        private UserInterfaceManager _uiManager;
        
        public override void OnButtonClick()
        {
            _uiManager.OnSpawnButtonClicked();
        }

        [Inject]
        private void Construct(UserInterfaceManager uiManager)
        {
            _uiManager = uiManager;
        }
    }
}
