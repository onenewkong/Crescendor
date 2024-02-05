using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static SongManager;

public class UI_Select : UI_Scene
{
    enum GameObjects
    {
        SongPanel,
        RankPanel,
    }

    enum Buttons
    {
        RankButton,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.RankButton).gameObject.BindEvent(OnRankButtonClick);
        GameObject songPanel = Get<GameObject>((int)GameObjects.SongPanel);
        SongManager.Instance.LoadSongsFromConvertsFolder();
        foreach (Transform child in songPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // SongManager�� �� ������ �̿��Ͽ� ��ư ����
        for (int i = 0; i < SongManager.Instance.songs.Count; i++)
        {
            // SongButton ������ �ε�
            GameObject songButtonPrefab = Managers.Resource.Instantiate($"UI/Sub/SongButton", songPanel.transform);
            // SongButton ����
            if (songButtonPrefab != null)
            {
                Button button = songButtonPrefab.GetComponent<Button>();

                // Song ������ ��ư�� ǥ��
                if (button != null)
                {
                    // ���÷� Song�� songTitle�� ��ư�� ǥ��
                    button.GetComponentInChildren<TextMeshProUGUI>().text = SongManager.Instance.songs[i].songTitle;
                    button.onClick.AddListener(() => OnSongButtonClick());
                }
            }
            else
            {
                Debug.LogError($"Failed to load SongButton prefab");
            }
        }

    }

    public void OnSongButtonClick()
    {
        Managers.UI.ShowPopupUI<UI_SongPopup>();
    }

    public void OnRankButtonClick(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_RankPopUp>();
    }


}
