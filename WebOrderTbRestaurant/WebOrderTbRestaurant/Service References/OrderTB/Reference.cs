﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebOrderTbRestaurant.OrderTB {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderTable", Namespace="http://schemas.datacontract.org/2004/07/Order_RestaurantWCF.Model")]
    [System.SerializableAttribute()]
    public partial class OrderTable : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> Count_peopleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CreatedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DateBookField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Full_NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TimeBookField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Count_people {
            get {
                return this.Count_peopleField;
            }
            set {
                if ((this.Count_peopleField.Equals(value) != true)) {
                    this.Count_peopleField = value;
                    this.RaisePropertyChanged("Count_people");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> CreatedDate {
            get {
                return this.CreatedDateField;
            }
            set {
                if ((this.CreatedDateField.Equals(value) != true)) {
                    this.CreatedDateField = value;
                    this.RaisePropertyChanged("CreatedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DateBook {
            get {
                return this.DateBookField;
            }
            set {
                if ((object.ReferenceEquals(this.DateBookField, value) != true)) {
                    this.DateBookField = value;
                    this.RaisePropertyChanged("DateBook");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Full_Name {
            get {
                return this.Full_NameField;
            }
            set {
                if ((object.ReferenceEquals(this.Full_NameField, value) != true)) {
                    this.Full_NameField = value;
                    this.RaisePropertyChanged("Full_Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TimeBook {
            get {
                return this.TimeBookField;
            }
            set {
                if ((object.ReferenceEquals(this.TimeBookField, value) != true)) {
                    this.TimeBookField = value;
                    this.RaisePropertyChanged("TimeBook");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderTB.IOrderSV")]
    public interface IOrderSV {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderSV/Insert", ReplyAction="http://tempuri.org/IOrderSV/InsertResponse")]
        bool Insert(WebOrderTbRestaurant.OrderTB.OrderTable or);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderSV/Insert", ReplyAction="http://tempuri.org/IOrderSV/InsertResponse")]
        System.Threading.Tasks.Task<bool> InsertAsync(WebOrderTbRestaurant.OrderTB.OrderTable or);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderSVChannel : WebOrderTbRestaurant.OrderTB.IOrderSV, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderSVClient : System.ServiceModel.ClientBase<WebOrderTbRestaurant.OrderTB.IOrderSV>, WebOrderTbRestaurant.OrderTB.IOrderSV {
        
        public OrderSVClient() {
        }
        
        public OrderSVClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderSVClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Insert(WebOrderTbRestaurant.OrderTB.OrderTable or) {
            return base.Channel.Insert(or);
        }
        
        public System.Threading.Tasks.Task<bool> InsertAsync(WebOrderTbRestaurant.OrderTB.OrderTable or) {
            return base.Channel.InsertAsync(or);
        }
    }
}
