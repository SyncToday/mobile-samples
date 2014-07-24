﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 12.0.21005.1
// 
namespace TaskyWin8.SyncTodayServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://sync.today/", ConfigurationName="SyncTodayServiceReference.TaskDatabaseSoap")]
    public interface TaskDatabaseSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccount2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.Account> GetAccount2Async(string accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTasks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask[]> GetTasksAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTasks2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask[]> GetTasks2Async(string accountId, string userInternalId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTask", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> GetTaskAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTask2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> GetTask2Async(string accountId, string userInternalId, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/SaveTask", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> SaveTaskAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user, TaskyWin8.SyncTodayServiceReference.NuTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/ChangeTaskExternalId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> ChangeTaskExternalIdAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user, string oldId, TaskyWin8.SyncTodayServiceReference.NuTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetUserSalt", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<string> GetUserSaltAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/LoginUser2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.User> LoginUser2Async(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccountForClient2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.Account> GetAccountForClient2Async(string userid, string clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetUsers2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DataNuObjectRelation))]
        System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.User[]> GetUsers2Async();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class Account : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid internalIdField;
        
        private System.Guid belongsToUserField;
        
        private string usernameField;
        
        private string passwordField;
        
        private string serverField;
        
        private string accountAssemblyNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Guid InternalId {
            get {
                return this.internalIdField;
            }
            set {
                this.internalIdField = value;
                this.RaisePropertyChanged("InternalId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.Guid BelongsToUser {
            get {
                return this.belongsToUserField;
            }
            set {
                this.belongsToUserField = value;
                this.RaisePropertyChanged("BelongsToUser");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Server {
            get {
                return this.serverField;
            }
            set {
                this.serverField = value;
                this.RaisePropertyChanged("Server");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string AccountAssemblyName {
            get {
                return this.accountAssemblyNameField;
            }
            set {
                this.accountAssemblyNameField = value;
                this.RaisePropertyChanged("AccountAssemblyName");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class NuContactName : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuContact))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuTask))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuRequirement))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class NuObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string externalIdField;
        
        private System.DateTime lastModifiedField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ExternalId {
            get {
                return this.externalIdField;
            }
            set {
                this.externalIdField = value;
                this.RaisePropertyChanged("ExternalId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime LastModified {
            get {
                return this.lastModifiedField;
            }
            set {
                this.lastModifiedField = value;
                this.RaisePropertyChanged("LastModified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class NuContact : NuObject {
        
        private NuContactName nameField;
        
        private TaskyWin8.SyncTodayServiceReference.ArrayOfXElement phoneNumbersField;
        
        private TaskyWin8.SyncTodayServiceReference.ArrayOfXElement emailAddressesField;
        
        private string addressField;
        
        private TaskyWin8.SyncTodayServiceReference.ArrayOfXElement physicalAddressesField;
        
        private string jobPositionField;
        
        private string companyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public NuContactName Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public TaskyWin8.SyncTodayServiceReference.ArrayOfXElement PhoneNumbers {
            get {
                return this.phoneNumbersField;
            }
            set {
                this.phoneNumbersField = value;
                this.RaisePropertyChanged("PhoneNumbers");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public TaskyWin8.SyncTodayServiceReference.ArrayOfXElement EmailAddresses {
            get {
                return this.emailAddressesField;
            }
            set {
                this.emailAddressesField = value;
                this.RaisePropertyChanged("EmailAddresses");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
                this.RaisePropertyChanged("Address");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public TaskyWin8.SyncTodayServiceReference.ArrayOfXElement PhysicalAddresses {
            get {
                return this.physicalAddressesField;
            }
            set {
                this.physicalAddressesField = value;
                this.RaisePropertyChanged("PhysicalAddresses");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string JobPosition {
            get {
                return this.jobPositionField;
            }
            set {
                this.jobPositionField = value;
                this.RaisePropertyChanged("JobPosition");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
                this.RaisePropertyChanged("Company");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class schema : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuRequirement))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class NuTask : NuObject {
        
        private string subjectField;
        
        private string bodyField;
        
        private System.Nullable<System.DateTime> startDateField;
        
        private System.Nullable<System.DateTime> dueDateField;
        
        private System.Nullable<System.DateTime> reminderField;
        
        private NuTaskPriority priorityField;
        
        private bool isPrivateField;
        
        private string companyField;
        
        private bool completedField;
        
        private string projectNameField;
        
        private NuRequirement[] parentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
                this.RaisePropertyChanged("Subject");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
                this.RaisePropertyChanged("Body");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public System.Nullable<System.DateTime> StartDate {
            get {
                return this.startDateField;
            }
            set {
                this.startDateField = value;
                this.RaisePropertyChanged("StartDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public System.Nullable<System.DateTime> DueDate {
            get {
                return this.dueDateField;
            }
            set {
                this.dueDateField = value;
                this.RaisePropertyChanged("DueDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public System.Nullable<System.DateTime> Reminder {
            get {
                return this.reminderField;
            }
            set {
                this.reminderField = value;
                this.RaisePropertyChanged("Reminder");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public NuTaskPriority Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
                this.RaisePropertyChanged("Priority");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public bool IsPrivate {
            get {
                return this.isPrivateField;
            }
            set {
                this.isPrivateField = value;
                this.RaisePropertyChanged("IsPrivate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
                this.RaisePropertyChanged("Company");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public bool Completed {
            get {
                return this.completedField;
            }
            set {
                this.completedField = value;
                this.RaisePropertyChanged("Completed");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string ProjectName {
            get {
                return this.projectNameField;
            }
            set {
                this.projectNameField = value;
                this.RaisePropertyChanged("ProjectName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=10)]
        public NuRequirement[] Parents {
            get {
                return this.parentsField;
            }
            set {
                this.parentsField = value;
                this.RaisePropertyChanged("Parents");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class NuRequirement : NuTask {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DataNuObjectRelationOfNuUser))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(User))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class DataNuObjectRelation : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid internalIdField;
        
        private System.Guid belongsToUserField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Guid InternalId {
            get {
                return this.internalIdField;
            }
            set {
                this.internalIdField = value;
                this.RaisePropertyChanged("InternalId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.Guid BelongsToUser {
            get {
                return this.belongsToUserField;
            }
            set {
                this.belongsToUserField = value;
                this.RaisePropertyChanged("BelongsToUser");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(User))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class DataNuObjectRelationOfNuUser : DataNuObjectRelation {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class User : DataNuObjectRelationOfNuUser {
        
        private System.DateTime createdField;
        
        private bool isBlockedField;
        
        private int maintenanceField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string emailField;
        
        private string passwordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.DateTime Created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
                this.RaisePropertyChanged("Created");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool IsBlocked {
            get {
                return this.isBlockedField;
            }
            set {
                this.isBlockedField = value;
                this.RaisePropertyChanged("IsBlocked");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Maintenance {
            get {
                return this.maintenanceField;
            }
            set {
                this.maintenanceField = value;
                this.RaisePropertyChanged("Maintenance");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
                this.RaisePropertyChanged("FirstName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
                this.RaisePropertyChanged("LastName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TaskDatabaseSoapChannel : TaskyWin8.SyncTodayServiceReference.TaskDatabaseSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskDatabaseSoapClient : System.ServiceModel.ClientBase<TaskyWin8.SyncTodayServiceReference.TaskDatabaseSoap>, TaskyWin8.SyncTodayServiceReference.TaskDatabaseSoap {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TaskDatabaseSoapClient() : 
                base(TaskDatabaseSoapClient.GetDefaultBinding(), TaskDatabaseSoapClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.TaskDatabaseSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaskDatabaseSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(TaskDatabaseSoapClient.GetBindingForEndpoint(endpointConfiguration), TaskDatabaseSoapClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaskDatabaseSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TaskDatabaseSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaskDatabaseSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TaskDatabaseSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TaskDatabaseSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.Account> GetAccount2Async(string accountId) {
            return base.Channel.GetAccount2Async(accountId);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask[]> GetTasksAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user) {
            return base.Channel.GetTasksAsync(account, user);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask[]> GetTasks2Async(string accountId, string userInternalId) {
            return base.Channel.GetTasks2Async(accountId, userInternalId);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> GetTaskAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user, string id) {
            return base.Channel.GetTaskAsync(account, user, id);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> GetTask2Async(string accountId, string userInternalId, string id) {
            return base.Channel.GetTask2Async(accountId, userInternalId, id);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> SaveTaskAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user, TaskyWin8.SyncTodayServiceReference.NuTask task) {
            return base.Channel.SaveTaskAsync(account, user, task);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.NuTask> ChangeTaskExternalIdAsync(TaskyWin8.SyncTodayServiceReference.Account account, TaskyWin8.SyncTodayServiceReference.User user, string oldId, TaskyWin8.SyncTodayServiceReference.NuTask task) {
            return base.Channel.ChangeTaskExternalIdAsync(account, user, oldId, task);
        }
        
        public System.Threading.Tasks.Task<string> GetUserSaltAsync(string email) {
            return base.Channel.GetUserSaltAsync(email);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.User> LoginUser2Async(string email, string password) {
            return base.Channel.LoginUser2Async(email, password);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.Account> GetAccountForClient2Async(string userid, string clientId) {
            return base.Channel.GetAccountForClient2Async(userid, clientId);
        }
        
        public System.Threading.Tasks.Task<TaskyWin8.SyncTodayServiceReference.User[]> GetUsers2Async() {
            return base.Channel.GetUsers2Async();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.TaskDatabaseSoap)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.TaskDatabaseSoap)) {
                return new System.ServiceModel.EndpointAddress("http://wsdl.sync.today/TaskDatabase.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return TaskDatabaseSoapClient.GetBindingForEndpoint(EndpointConfiguration.TaskDatabaseSoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return TaskDatabaseSoapClient.GetEndpointAddress(EndpointConfiguration.TaskDatabaseSoap);
        }
        
        public enum EndpointConfiguration {
            
            TaskDatabaseSoap,
        }
    }
    
    [System.Xml.Serialization.XmlSchemaProviderAttribute(null, IsAny=true)]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.ServiceReference.Platforms", "12.0.0.0")]
    public partial class ArrayOfXElement : object, System.Xml.Serialization.IXmlSerializable {
        
        private System.Collections.Generic.List<System.Xml.Linq.XElement> nodesList = new System.Collections.Generic.List<System.Xml.Linq.XElement>();
        
        public ArrayOfXElement() {
        }
        
        public virtual System.Collections.Generic.List<System.Xml.Linq.XElement> Nodes {
            get {
                return this.nodesList;
            }
        }
        
        public virtual System.Xml.Schema.XmlSchema GetSchema() {
            throw new System.NotImplementedException();
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer) {
            System.Collections.Generic.IEnumerator<System.Xml.Linq.XElement> e = nodesList.GetEnumerator();
            for (
            ; e.MoveNext(); 
            ) {
                ((System.Xml.Serialization.IXmlSerializable)(e.Current)).WriteXml(writer);
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader) {
            for (
            ; (reader.NodeType != System.Xml.XmlNodeType.EndElement); 
            ) {
                if ((reader.NodeType == System.Xml.XmlNodeType.Element)) {
                    System.Xml.Linq.XElement elem = new System.Xml.Linq.XElement("default");
                    ((System.Xml.Serialization.IXmlSerializable)(elem)).ReadXml(reader);
                    Nodes.Add(elem);
                }
                else {
                    reader.Skip();
                }
            }
        }
    }
}
