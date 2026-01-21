using Screens;
using Zenject;

namespace Controlles
{
    public class GameFlowController : IInitializable
    {
        [Inject] private ScreenNavigator nav;

        public void Initialize()
        {
            nav.Push<MainScreen>();
        }
    }
}