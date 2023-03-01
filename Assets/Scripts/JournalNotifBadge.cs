using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalNotifBadge : MonoBehaviour
{
    public TMP_Text _notifBadgeNumber;
    Image _badgeImage;

    void Start()
    {
        _badgeImage = GetComponent<Image>();
    }

    void Update()
    {
        int num = PublicVars.GetNewFlagCount();
        _notifBadgeNumber.text = num.ToString();
        _badgeImage.enabled = (num != 0);
        _notifBadgeNumber.enabled = (num != 0);
    }
}
