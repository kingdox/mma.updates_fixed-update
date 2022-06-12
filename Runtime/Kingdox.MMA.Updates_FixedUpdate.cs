#region Access
using System;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
namespace MMA.Updates
{
    public static partial class Key
    {
        // public const string _   = KeyData._;
        public static string SubscribeFixed = "Updates_SubscribeFixed";
    }

    public sealed partial class Updates_Module : Module
    {
        #region References
        //[Header("Applications")]
        //[SerializeField] public ApplicationBase interface_Updates;
        private readonly Dictionary<int, Action> dic_updates_fixed = new Dictionary<int, Action>();

        #endregion
        #region Events
        private void FixedUpdate()
        {
            //Debug.Log(frameCount);
            foreach (var item in dic_updates_fixed)
            {
                if (frameCount % item.Key == 0) item.Value.Invoke();
            }
        }
        #endregion
        #region Reactions ( On___ )
        // Contenedor de toda las reacciones del Updates
        //protected override void OnSubscription(bool condition)
        //{
        //}
        #endregion
        #region Methods
        // Contenedor de toda la logica del Updates
        private void SubscribeUpdateFixed((bool condition, int framecount, Action callback) value)
        {
            if (value.condition)
            {

                if (!dic_updates_fixed.ContainsKey(value.framecount))
                {
                    dic_updates_fixed.Add(value.framecount, default);
                }

                dic_updates_fixed[value.framecount] += value.callback;

            }
            else
            {
                dic_updates_fixed[value.framecount] -= value.callback;

                if (dic_updates_fixed[value.framecount] == null)
                {
                    dic_updates_fixed.Remove(value.framecount);
                }

            }
        }
        #endregion
        #region Request ( Coroutines )
        // Contenedor de toda la Esperas de corutinas del Updates
        #endregion
        #region Task ( async )
        // Contenedor de toda la Esperas asincronas del Updates
        #endregion
    }
}