﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebOrderTbRestaurant.Main_Menu {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Main_Menu", Namespace="http://schemas.datacontract.org/2004/07/Order_RestaurantWCF.Model")]
    [System.SerializableAttribute()]
    public partial class Main_Menu : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> DisplayOrderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> StatusField;
        
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
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> DisplayOrder {
            get {
                return this.DisplayOrderField;
            }
            set {
                if ((this.DisplayOrderField.Equals(value) != true)) {
                    this.DisplayOrderField = value;
                    this.RaisePropertyChanged("DisplayOrder");
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
        public string Link {
            get {
                return this.LinkField;
            }
            set {
                if ((object.ReferenceEquals(this.LinkField, value) != true)) {
                    this.LinkField = value;
                    this.RaisePropertyChanged("Link");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Footer", Namespace="http://schemas.datacontract.org/2004/07/Order_RestaurantWCF.Model")]
    [System.SerializableAttribute()]
    public partial class Footer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> StatusField;
        
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
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Main_Menu.IMenuSV")]
    public interface IMenuSV {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuSV/ListMenu", ReplyAction="http://tempuri.org/IMenuSV/ListMenuResponse")]
        WebOrderTbRestaurant.Main_Menu.Main_Menu[] ListMenu();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuSV/ListMenu", ReplyAction="http://tempuri.org/IMenuSV/ListMenuResponse")]
        System.Threading.Tasks.Task<WebOrderTbRestaurant.Main_Menu.Main_Menu[]> ListMenuAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuSV/ListFooter", ReplyAction="http://tempuri.org/IMenuSV/ListFooterResponse")]
        WebOrderTbRestaurant.Main_Menu.Footer ListFooter();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMenuSV/ListFooter", ReplyAction="http://tempuri.org/IMenuSV/ListFooterResponse")]
        System.Threading.Tasks.Task<WebOrderTbRestaurant.Main_Menu.Footer> ListFooterAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMenuSVChannel : WebOrderTbRestaurant.Main_Menu.IMenuSV, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MenuSVClient : System.ServiceModel.ClientBase<WebOrderTbRestaurant.Main_Menu.IMenuSV>, WebOrderTbRestaurant.Main_Menu.IMenuSV {
        
        public MenuSVClient() {
        }
        
        public MenuSVClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MenuSVClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebOrderTbRestaurant.Main_Menu.Main_Menu[] ListMenu() {
            return base.Channel.ListMenu();
        }
        
        public System.Threading.Tasks.Task<WebOrderTbRestaurant.Main_Menu.Main_Menu[]> ListMenuAsync() {
            return base.Channel.ListMenuAsync();
        }
        
        public WebOrderTbRestaurant.Main_Menu.Footer ListFooter() {
            return base.Channel.ListFooter();
        }
        
        public System.Threading.Tasks.Task<WebOrderTbRestaurant.Main_Menu.Footer> ListFooterAsync() {
            return base.Channel.ListFooterAsync();
        }
    }
}
