using System;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Web;
using Microsoft.Practices.Unity;

namespace UDataCore.Uow
{
    public class PerRequestLifetimeManager : LifetimeManager
    {
        private readonly Guid _key = Guid.NewGuid();

        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_key] = newValue;
        }

        public override void RemoveValue()
        {
            var obj = GetValue();
            HttpContext.Current.Items.Remove(obj);
        }
    }
}