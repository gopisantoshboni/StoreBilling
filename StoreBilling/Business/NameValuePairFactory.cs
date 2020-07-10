using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreBilling.Models;
using StoreBilling.DAL;

namespace StoreBilling.Business
{
    public class NameValuePairFactory
    {
        public NameValuePair GetValue(string Name)
        {            
            NameValuePairData nameValuePairData = new NameValuePairData();
            return nameValuePairData.GetValue(Name);            
        }
    }
}