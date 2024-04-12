using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [FriendOf(typeof(YIUIComponent))]
    [FriendOf(typeof(YIUIWindowComponent))]
    [FriendOf(typeof(YIUIPanelComponent))]
    [EntitySystemOf(typeof(SkillPanelComponent))]
    public static partial class SkillPanelComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillPanelComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this SkillPanelComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this SkillPanelComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();
            self.u_UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.u_UIPanel = self.UIBase.GetComponent<YIUIPanelComponent>();
            self.UIWindow.WindowOption = EWindowOption.BanTween;
            self.UIPanel.Layer = EPanelLayer.Panel;
            self.UIPanel.PanelOption = EPanelOption.TimeCache;
            self.UIPanel.StackOption = EPanelStackOption.VisibleTween;
            self.UIPanel.Priority = 0;
            self.UIPanel.CachePanelTime = 10;

            self.u_EventClickSkill = self.UIBase.EventTable.FindEvent<UIEventP1<int>>("u_EventClickSkill");
            self.u_EventClickSkillHandle = self.u_EventClickSkill.Add(self.OnEventClickSkillAction);

        }
    }
}