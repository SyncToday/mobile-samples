//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tasky.Droid.SyncTodayServiceReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TaskDatabaseSoap", Namespace="http://sync.today/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuObject))]
    public partial class TaskDatabase : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public TaskDatabase() {
            this.Url = "http://wsdl.sync.today/TaskDatabase.asmx";
        }
        
        public TaskDatabase(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetAccount", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Account GetAccount(System.Guid accountId) {
            object[] results = this.Invoke("GetAccount", new object[] {
                        accountId});
            return ((Account)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAccount(System.Guid accountId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAccount", new object[] {
                        accountId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Account EndGetAccount(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Account)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetAccount2", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Account GetAccount2(string accountId) {
            object[] results = this.Invoke("GetAccount2", new object[] {
                        accountId});
            return ((Account)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAccount2(string accountId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAccount2", new object[] {
                        accountId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Account EndGetAccount2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Account)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetTasks", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public NuTask[] GetTasks(Account account, User user) {
            object[] results = this.Invoke("GetTasks", new object[] {
                        account,
                        user});
            return ((NuTask[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTasks(Account account, User user, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTasks", new object[] {
                        account,
                        user}, callback, asyncState);
        }
        
        /// <remarks/>
        public NuTask[] EndGetTasks(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((NuTask[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetTasks2", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public NuTask[] GetTasks2(string accountId, string userInternalId) {
            object[] results = this.Invoke("GetTasks2", new object[] {
                        accountId,
                        userInternalId});
            return ((NuTask[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTasks2(string accountId, string userInternalId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTasks2", new object[] {
                        accountId,
                        userInternalId}, callback, asyncState);
        }
        
        /// <remarks/>
        public NuTask[] EndGetTasks2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((NuTask[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetTask", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public NuTask GetTask(Account account, User user, string id) {
            object[] results = this.Invoke("GetTask", new object[] {
                        account,
                        user,
                        id});
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTask(Account account, User user, string id, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTask", new object[] {
                        account,
                        user,
                        id}, callback, asyncState);
        }
        
        /// <remarks/>
        public NuTask EndGetTask(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetTask2", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public NuTask GetTask2(string accountId, string userInternalId, string id) {
            object[] results = this.Invoke("GetTask2", new object[] {
                        accountId,
                        userInternalId,
                        id});
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTask2(string accountId, string userInternalId, string id, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTask2", new object[] {
                        accountId,
                        userInternalId,
                        id}, callback, asyncState);
        }
        
        /// <remarks/>
        public NuTask EndGetTask2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/SaveTask", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public NuTask SaveTask(Account account, User user, NuTask task) {
            object[] results = this.Invoke("SaveTask", new object[] {
                        account,
                        user,
                        task});
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSaveTask(Account account, User user, NuTask task, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SaveTask", new object[] {
                        account,
                        user,
                        task}, callback, asyncState);
        }
        
        /// <remarks/>
        public NuTask EndSaveTask(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/ChangeTaskExternalId", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public NuTask ChangeTaskExternalId(Account account, User user, string oldId, NuTask task) {
            object[] results = this.Invoke("ChangeTaskExternalId", new object[] {
                        account,
                        user,
                        oldId,
                        task});
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginChangeTaskExternalId(Account account, User user, string oldId, NuTask task, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ChangeTaskExternalId", new object[] {
                        account,
                        user,
                        oldId,
                        task}, callback, asyncState);
        }
        
        /// <remarks/>
        public NuTask EndChangeTaskExternalId(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((NuTask)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetUserSalt", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUserSalt(string email) {
            object[] results = this.Invoke("GetUserSalt", new object[] {
                        email});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetUserSalt(string email, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetUserSalt", new object[] {
                        email}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetUserSalt(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/LoginUser", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool LoginUser(User user) {
            object[] results = this.Invoke("LoginUser", new object[] {
                        user});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLoginUser(User user, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("LoginUser", new object[] {
                        user}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndLoginUser(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/LoginUser2", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public User LoginUser2(string email, string password) {
            object[] results = this.Invoke("LoginUser2", new object[] {
                        email,
                        password});
            return ((User)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLoginUser2(string email, string password, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("LoginUser2", new object[] {
                        email,
                        password}, callback, asyncState);
        }
        
        /// <remarks/>
        public User EndLoginUser2(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((User)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sync.today/GetAccountForClient", RequestNamespace="http://sync.today/", ResponseNamespace="http://sync.today/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Account GetAccountForClient(System.Guid userid, System.Guid clientId) {
            object[] results = this.Invoke("GetAccountForClient", new object[] {
                        userid,
                        clientId});
            return ((Account)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAccountForClient(System.Guid userid, System.Guid clientId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAccountForClient", new object[] {
                        userid,
                        clientId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Account EndGetAccountForClient(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Account)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class Account {
        
        /// <remarks/>
        public System.Guid InternalId;
        
        /// <remarks/>
        public System.Guid BelongsToUser;
        
        /// <remarks/>
        public string Username;
        
        /// <remarks/>
        public string Password;
        
        /// <remarks/>
        public string Server;
        
        /// <remarks/>
        public CommunicatorConnectInfo ConnectInfo;
        
        /// <remarks/>
        public string AccountAssemblyName;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimpleCommunicatorConnectInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class CommunicatorConnectInfo {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuTask))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuRequirement))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class NuObject {
        
        /// <remarks/>
        public string ExternalId;
        
        /// <remarks/>
        public System.DateTime LastModified;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuRequirement))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class NuTask : NuObject {
        
        /// <remarks/>
        public string Subject;
        
        /// <remarks/>
        public string Body;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> StartDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> DueDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> Reminder;
        
        /// <remarks/>
        public NuTaskPriority Priority;
        
        /// <remarks/>
        public bool IsPrivate;
        
        /// <remarks/>
        public string Company;
        
        /// <remarks/>
        public bool Completed;
        
        /// <remarks/>
        public NuRequirement[] Parents;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public enum NuTaskPriority {
        
        /// <remarks/>
        Low,
        
        /// <remarks/>
        Normal,
        
        /// <remarks/>
        High,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class NuRequirement : NuTask {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class User {
        
        /// <remarks/>
        public System.Guid InternalId;
        
        /// <remarks/>
        public System.DateTime Created;
        
        /// <remarks/>
        public bool IsBlocked;
        
        /// <remarks/>
        public int Maintenance;
        
        /// <remarks/>
        public string FirstName;
        
        /// <remarks/>
        public string LastName;
        
        /// <remarks/>
        public string Email;
        
        /// <remarks/>
        public string Password;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class SimpleCommunicatorConnectInfo : CommunicatorConnectInfo {
        
        /// <remarks/>
        public string Username;
        
        /// <remarks/>
        public string Password;
        
        /// <remarks/>
        public string Server;
        
        /// <remarks/>
        public System.Guid InternalId;
    }
}
