using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareMemory
{
    public static class OperationWork
    {
       static Dictionary<string, string> DataStore = new Dictionary<string, string>();

        public static string Getdata(GetdataRequest request)
        {
            string value=null;
            if(DataStore.ContainsKey(request.UserId))
            {
                value=DataStore[request.UserId];
            }
            return value;
        }

        public static bool Setdata(SetdataRequest request)
        {
            bool result = false;
            if (DataStore.ContainsKey(request.UserId))
            {
                result = false;
            }
            else
            {
                DataStore.Add(request.UserId, request.Data);
                result = true;
            }
            return result;
        }
    }
}