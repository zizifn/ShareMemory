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

            // in the full sharememory, we should add logic here
            // 1. we need check userid have or didn't have access to get data
            if(DataStore.ContainsKey(request.UserId))
            {
                value=DataStore[request.UserId];
            }
            return value;
        }

        public static bool Setdata(SetdataRequest request)
        {
            bool result = false;

            // in the full sharememory, we should add logic here
            // 1. we need check userid have or didn't have access to set data

            if (DataStore.ContainsKey(request.UserId))
            {
                DataStore[request.UserId] = request.Data;
                result = true;
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