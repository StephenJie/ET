using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// Author  YIUI
    /// Date    2024.4.1
    /// Desc
    /// </summary>
    [FriendOf(typeof(SkillPanelComponent))]
    public static partial class SkillPanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this SkillPanelComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SkillPanelComponent self)
        {
        }
        
        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this SkillPanelComponent self)
        {
            await ETTask.CompletedTask;
            return true;
        }
        
        #region YIUIEvent开始
        
        
        private static void OnEventClickSkillAction(this SkillPanelComponent self, int p1)
        {
            //Debug.Log("ss");
            Log.Debug("skill" + p1);

        }
        #endregion YIUIEvent结束
    }
}