using System;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using NUnit.Framework;

namespace UService.Test
{
    public class TaxCalculator
    {
        private decimal _rate = 0.125M;
        public decimal Rate
        {
            set { _rate = value; }
            get { return _rate; }
        }
        public decimal CalculateTax(decimal gross)
        {
            return Math.Round(_rate * gross, 2);
        }
        [Test]
        public void test()
        {
            Castle.Core.Resource.ConfigResource source = new Castle.Core.Resource.ConfigResource();
            XmlInterpreter interpreter = new XmlInterpreter(source);
            WindsorContainer windsor = new WindsorContainer(interpreter);
            TaxCalculator calculator = windsor.Resolve<TaxCalculator>();
            decimal gross = 100;
            decimal tax = calculator.CalculateTax(gross);
        }
    }
}