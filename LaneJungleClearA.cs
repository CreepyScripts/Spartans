﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Spartan_Annie
{
    internal class LaneJungleClearA
    {
        public enum AttackSpell
        {
            Q,
            W
        };

        public static AIHeroClient Annie
        {
            get { return ObjectManager.Player; }
        }

        public static Obj_AI_Base GetEnemy(float range, GameObjectType t)
        {
            switch (t)
            {
                case GameObjectType.AIHeroClient:
                    return EntityManager.Heroes.Enemies.OrderBy(a => a.Health).FirstOrDefault(
                        a => a.Distance(Player.Instance) < range && !a.IsDead && !a.IsInvulnerable);
                default:
                    return EntityManager.MinionsAndMonsters.EnemyMinions.OrderBy(a => a.Health).FirstOrDefault(
                        a => a.Distance(Player.Instance) < range && !a.IsDead && !a.IsInvulnerable);
            }
        }

        public static void LaneClear()
        {
            var qcheck = Program.LaneJungleClear["Lane Clear Q"].Cast<CheckBox>().CurrentValue;
            var qready = Program.Q.IsReady();
            var wcheck = Program.LaneJungleClear["Lane Clear W"].Cast<CheckBox>().CurrentValue;
            var wready = Program.W.IsReady();

            if (qcheck && qready)
            {
            var qenemy = (Obj_AI_Minion) GetEnemy(Program.Q.Range, GameObjectType.obj_AI_Minion);
            if (qenemy != null)
                {
                    Program.Q.Cast(qenemy);
                }
            if (wcheck && wready)
            {
            var wminion = (Obj_AI_Minion) GetEnemy(Program.W.Range, GameObjectType.obj_AI_Minion);
            if (wminion != null)
                {
                    Program.W.Cast(wminion.ServerPosition);
                }
        }
    }
        }
    }
}