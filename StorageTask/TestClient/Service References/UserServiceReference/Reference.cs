﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.UserServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Entities")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.DateTime Birthdayk__BackingFieldField;
        
        private string FirstNamek__BackingFieldField;
        
        private TestClient.UserServiceReference.Gender Genderk__BackingFieldField;
        
        private int Idk__BackingFieldField;
        
        private string LastNamek__BackingFieldField;
        
        private TestClient.UserServiceReference.VisaRecord[] VisaRecordsk__BackingFieldField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Birthday>k__BackingField", IsRequired=true)]
        public System.DateTime Birthdayk__BackingField {
            get {
                return this.Birthdayk__BackingFieldField;
            }
            set {
                if ((this.Birthdayk__BackingFieldField.Equals(value) != true)) {
                    this.Birthdayk__BackingFieldField = value;
                    this.RaisePropertyChanged("Birthdayk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<FirstName>k__BackingField", IsRequired=true)]
        public string FirstNamek__BackingField {
            get {
                return this.FirstNamek__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNamek__BackingFieldField, value) != true)) {
                    this.FirstNamek__BackingFieldField = value;
                    this.RaisePropertyChanged("FirstNamek__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Gender>k__BackingField", IsRequired=true)]
        public TestClient.UserServiceReference.Gender Genderk__BackingField {
            get {
                return this.Genderk__BackingFieldField;
            }
            set {
                if ((this.Genderk__BackingFieldField.Equals(value) != true)) {
                    this.Genderk__BackingFieldField = value;
                    this.RaisePropertyChanged("Genderk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Id>k__BackingField", IsRequired=true)]
        public int Idk__BackingField {
            get {
                return this.Idk__BackingFieldField;
            }
            set {
                if ((this.Idk__BackingFieldField.Equals(value) != true)) {
                    this.Idk__BackingFieldField = value;
                    this.RaisePropertyChanged("Idk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<LastName>k__BackingField", IsRequired=true)]
        public string LastNamek__BackingField {
            get {
                return this.LastNamek__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNamek__BackingFieldField, value) != true)) {
                    this.LastNamek__BackingFieldField = value;
                    this.RaisePropertyChanged("LastNamek__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<VisaRecords>k__BackingField", IsRequired=true)]
        public TestClient.UserServiceReference.VisaRecord[] VisaRecordsk__BackingField {
            get {
                return this.VisaRecordsk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.VisaRecordsk__BackingFieldField, value) != true)) {
                    this.VisaRecordsk__BackingFieldField = value;
                    this.RaisePropertyChanged("VisaRecordsk__BackingField");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Gender", Namespace="http://schemas.datacontract.org/2004/07/Entities")]
    public enum Gender : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Male = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Female = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VisaRecord", Namespace="http://schemas.datacontract.org/2004/07/Entities")]
    [System.SerializableAttribute()]
    public partial struct VisaRecord : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string Countryk__BackingFieldField;
        
        private System.DateTime Fromk__BackingFieldField;
        
        private System.DateTime Untilk__BackingFieldField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Country>k__BackingField", IsRequired=true)]
        public string Countryk__BackingField {
            get {
                return this.Countryk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Countryk__BackingFieldField, value) != true)) {
                    this.Countryk__BackingFieldField = value;
                    this.RaisePropertyChanged("Countryk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<From>k__BackingField", IsRequired=true)]
        public System.DateTime Fromk__BackingField {
            get {
                return this.Fromk__BackingFieldField;
            }
            set {
                if ((this.Fromk__BackingFieldField.Equals(value) != true)) {
                    this.Fromk__BackingFieldField = value;
                    this.RaisePropertyChanged("Fromk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Until>k__BackingField", IsRequired=true)]
        public System.DateTime Untilk__BackingField {
            get {
                return this.Untilk__BackingFieldField;
            }
            set {
                if ((this.Untilk__BackingFieldField.Equals(value) != true)) {
                    this.Untilk__BackingFieldField = value;
                    this.RaisePropertyChanged("Untilk__BackingField");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TrueCriteria", Namespace="http://schemas.datacontract.org/2004/07/Storage.Criterias")]
    [System.SerializableAttribute()]
    public partial class TrueCriteria : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BirthdayCriteria", Namespace="http://schemas.datacontract.org/2004/07/Storage.Criterias")]
    [System.SerializableAttribute()]
    public partial class BirthdayCriteria : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/get_IsMaster", ReplyAction="http://tempuri.org/IUserService/get_IsMasterResponse")]
        bool get_IsMaster();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/get_IsMaster", ReplyAction="http://tempuri.org/IUserService/get_IsMasterResponse")]
        System.Threading.Tasks.Task<bool> get_IsMasterAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        int AddUser(TestClient.UserServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        System.Threading.Tasks.Task<int> AddUserAsync(TestClient.UserServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        void DeleteUser(TestClient.UserServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        System.Threading.Tasks.Task DeleteUserAsync(TestClient.UserServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/FindUsers", ReplyAction="http://tempuri.org/IUserService/FindUsersResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestClient.UserServiceReference.TrueCriteria))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestClient.UserServiceReference.BirthdayCriteria))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(int[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestClient.UserServiceReference.User))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestClient.UserServiceReference.Gender))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestClient.UserServiceReference.VisaRecord[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(TestClient.UserServiceReference.VisaRecord))]
        int[] FindUsers(object[] funcs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/FindUsers", ReplyAction="http://tempuri.org/IUserService/FindUsersResponse")]
        System.Threading.Tasks.Task<int[]> FindUsersAsync(object[] funcs);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : TestClient.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<TestClient.UserServiceReference.IUserService>, TestClient.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool get_IsMaster() {
            return base.Channel.get_IsMaster();
        }
        
        public System.Threading.Tasks.Task<bool> get_IsMasterAsync() {
            return base.Channel.get_IsMasterAsync();
        }
        
        public int AddUser(TestClient.UserServiceReference.User user) {
            return base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task<int> AddUserAsync(TestClient.UserServiceReference.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public void DeleteUser(TestClient.UserServiceReference.User user) {
            base.Channel.DeleteUser(user);
        }
        
        public System.Threading.Tasks.Task DeleteUserAsync(TestClient.UserServiceReference.User user) {
            return base.Channel.DeleteUserAsync(user);
        }
        
        public int[] FindUsers(object[] funcs) {
            return base.Channel.FindUsers(funcs);
        }
        
        public System.Threading.Tasks.Task<int[]> FindUsersAsync(object[] funcs) {
            return base.Channel.FindUsersAsync(funcs);
        }
    }
}
