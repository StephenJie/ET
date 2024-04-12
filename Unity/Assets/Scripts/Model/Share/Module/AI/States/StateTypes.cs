
using System;
using Sirenix.OdinInspector;

namespace ET
{
    [Flags]
    public enum StateTypes
    {
        None = 0,
        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        Run = 1 << 1,

        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        Idle = 1 << 2,

        /// <summary>
        /// �ͷż���
        /// </summary>
        [LabelText("�ͷż���")]
        Skill_Cast = 1 << 3,

        /// <summary>
        /// �չ�
        /// </summary>
        [LabelText("�չ�")]
        CommonAttack = 1 << 4,

        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        RePluse = 1 << 5,

        /// <summary>
        /// ��Ĭ
        /// </summary>
        [LabelText("��Ĭ")]
        Silence = 1 << 6,

        /// <summary>
        /// ѣ��
        /// </summary>
        [LabelText("ѣ��")]
        Dizziness = 1 << 7,

        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        Striketofly = 1 << 8,

        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        Sneer = 1 << 9,

        /// <summary>
        /// �޵�
        /// </summary>
        [LabelText("�޵�")]
        Invincible = 1 << 10,

        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        Shackle = 1 << 11,

        /// <summary>
        /// ����
        /// </summary>
        [LabelText("����")]
        Invisible = 1 << 12,

        /// <summary>
        /// �־�
        /// </summary>
        [LabelText("�־�")]
        Fear = 1 << 13,

        /// <summary>
        /// ��ä
        /// </summary>
        [LabelText("��ä")]
        Blind = 1 << 14,

        /// <summary>
        /// �ų��չ����д�״̬�޷��չ�
        /// </summary>
        [LabelText("�ų��չ�")]
        CommonAttackConflict = 1 << 15,

        /// <summary>
        /// �ų����ߣ��д�״̬�޷�����
        /// </summary>
        [LabelText("�ų�����")]
        WalkConflict = 1 << 16,

        /// <summary>
        /// �ų��ͷż��ܣ��д�״̬�޷��ͷż���
        /// </summary>
        [LabelText("�ų⼼���ͷ�")]
        CastSkillConflict = 1 << 17,
    }
}