/* 인게임 매니저
 * 작성 - 이원섭
 * 연주가 진행되면서 처리하거나 읽는데 공유가 필요한 데이터를 처리하기 위한 객체
 * 특정 씬에서 사용할 컨트롤러 스크립트를 변수로 저장하는 용도*/

using Unity.VisualScripting;
using static Define;

public class IngameManager
{
    public object controller;

    public void Init()
    {
        switch (Managers.Scene.currentScene)
        {
            case Scene.PracticeModScene:
                controller = Managers.ManagerInstance.GetComponent<PracticeModController>();
                if (controller == null)
                    controller = Managers.ManagerInstance.AddComponent<PracticeModController>();
                (controller as PracticeModController).Init();
                break;

            case Scene.ActualModScene:
                controller = Managers.ManagerInstance.GetComponent<ActualModController>();
                if (controller == null)
                    controller = Managers.ManagerInstance.AddComponent<ActualModController>();
                (controller as ActualModController).Init();
                break;
        }
    }
}
