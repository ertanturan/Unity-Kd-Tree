using Zenject;

namespace CodingTest.Scripts.UI.Components.Buttons
{
    public class SpawnCubeButton : ButtonComponent
    {

      
        public override void OnButtonClick()
        {
            _uiManager.OnSpawnButtonClicked();
        }

        private UserInterfaceManager _uiManager;

        
        [Inject]
        private void Construct(UserInterfaceManager uiManager)
        {
            _uiManager = uiManager;
        }
    }
}
