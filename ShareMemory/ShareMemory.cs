using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ShareMemory
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IShareMemory
    {

        [OperationContract]
        string GetData(GetdataRequest getdataRequest);

        [OperationContract]
        bool SetData(SetdataRequest setdataRequest);

    }

    [DataContract]
    public class GetdataRequest
    {
        [DataMember]
        public string UserId { get; set; }

    }

    [DataContract]
    public class SetdataRequest
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Data { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public bool UserID { get; set; }
        [DataMember]
        public bool Password { get; set; }
    }
    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
