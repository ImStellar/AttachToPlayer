﻿using System;
using ReMod.Core.UI;
using ReMod.Core.VRChat;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace ReMod.Core.Managers
{
    public class UiManager
    {
        public IButtonPage MainMenu { get; }
        public IButtonPage TargetMenu { get; }

        private static UiManager _instance;
        public UiManager(string menuName)
        {
            //if (_instance != null)
            //{
            //    throw new Exception("UiManager already exists.");
            //}
            _instance = this;

            FixLaunchpadScrolling();

            MainMenu = new ReMenuPage(menuName, true);
            //ReTabButton.Create(menuName, $"Open the {menuName} menu.", menuName);

            TargetMenu = new ReMenuCategory($"{menuName}", QuickMenuEx.Instance.field_Private_UIPage_1.transform.Find("ScrollRect").GetComponent<ScrollRect>().content);
        }

        private void FixLaunchpadScrolling()
        {
            var dashboard = QuickMenuEx.Instance.field_Public_Transform_0.Find("Window/QMParent/Menu_Dashboard").GetComponent<UIPage>();
            var scrollRect = dashboard.GetComponentInChildren<ScrollRect>();
            var dashboardScrollbar = scrollRect.transform.Find("Scrollbar").GetComponent<Scrollbar>();

            var dashboardContent = scrollRect.content;
            dashboardContent.GetComponent<VerticalLayoutGroup>().childControlHeight = true;

            scrollRect.enabled = true;
            scrollRect.verticalScrollbar = dashboardScrollbar;
            scrollRect.viewport.GetComponent<RectMask2D>().enabled = true;
        }
    }
}
