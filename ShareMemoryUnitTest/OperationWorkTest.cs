using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShareMemory;

namespace ShareMemoryUnitTest
{
    [TestClass]
    public class OperationWorkTest
    {
        [TestMethod]
        public void GetdataTest()
        {
            SetdataTest();
            for (int i = 0; i < 1000; i++)
            {
                GetdataRequest request = new GetdataRequest
                {
                    UserId = i.ToString()
                };
                string result=OperationWork.Getdata(request);
                string except = "Setdata " + i.ToString() + " times";
                Assert.AreEqual(result, except);
            }

        }
        [TestMethod]
        public void SetdataTest()
        {

            for (int i = 0; i < 1000;i++ )
            {
                string s = "Setdata " + i.ToString() + " times";
                SetdataRequest request = new SetdataRequest
                {
                    UserId = i.ToString(),
                    Data = s,
                };
                bool result = OperationWork.Setdata(request);
                Assert.IsTrue(result);
            }
            
        }
    }
}
