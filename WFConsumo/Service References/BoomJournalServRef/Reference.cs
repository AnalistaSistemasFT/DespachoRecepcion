﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WFConsumo.BoomJournalServRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CallContext", Namespace="http://schemas.microsoft.com/dynamics/2010/01/datacontracts")]
    [System.SerializableAttribute()]
    public partial class CallContext : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LanguageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LogonAsUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PartitionKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, string> PropertyBagField;
        
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
        public string Company {
            get {
                return this.CompanyField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyField, value) != true)) {
                    this.CompanyField = value;
                    this.RaisePropertyChanged("Company");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Language {
            get {
                return this.LanguageField;
            }
            set {
                if ((object.ReferenceEquals(this.LanguageField, value) != true)) {
                    this.LanguageField = value;
                    this.RaisePropertyChanged("Language");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LogonAsUser {
            get {
                return this.LogonAsUserField;
            }
            set {
                if ((object.ReferenceEquals(this.LogonAsUserField, value) != true)) {
                    this.LogonAsUserField = value;
                    this.RaisePropertyChanged("LogonAsUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageId {
            get {
                return this.MessageIdField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageIdField, value) != true)) {
                    this.MessageIdField = value;
                    this.RaisePropertyChanged("MessageId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PartitionKey {
            get {
                return this.PartitionKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.PartitionKeyField, value) != true)) {
                    this.PartitionKeyField = value;
                    this.RaisePropertyChanged("PartitionKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, string> PropertyBag {
            get {
                return this.PropertyBagField;
            }
            set {
                if ((object.ReferenceEquals(this.PropertyBagField, value) != true)) {
                    this.PropertyBagField = value;
                    this.RaisePropertyChanged("PropertyBag");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AifFault", Namespace="http://schemas.microsoft.com/dynamics/2008/01/documents/Fault")]
    [System.SerializableAttribute()]
    public partial class AifFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomDetailXmlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WFConsumo.BoomJournalServRef.FaultMessageList[] FaultMessageListArrayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WFConsumo.BoomJournalServRef.InfologMessage[] InfologMessageListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int XppExceptionTypeField;
        
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
        public string CustomDetailXml {
            get {
                return this.CustomDetailXmlField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomDetailXmlField, value) != true)) {
                    this.CustomDetailXmlField = value;
                    this.RaisePropertyChanged("CustomDetailXml");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WFConsumo.BoomJournalServRef.FaultMessageList[] FaultMessageListArray {
            get {
                return this.FaultMessageListArrayField;
            }
            set {
                if ((object.ReferenceEquals(this.FaultMessageListArrayField, value) != true)) {
                    this.FaultMessageListArrayField = value;
                    this.RaisePropertyChanged("FaultMessageListArray");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WFConsumo.BoomJournalServRef.InfologMessage[] InfologMessageList {
            get {
                return this.InfologMessageListField;
            }
            set {
                if ((object.ReferenceEquals(this.InfologMessageListField, value) != true)) {
                    this.InfologMessageListField = value;
                    this.RaisePropertyChanged("InfologMessageList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int XppExceptionType {
            get {
                return this.XppExceptionTypeField;
            }
            set {
                if ((this.XppExceptionTypeField.Equals(value) != true)) {
                    this.XppExceptionTypeField = value;
                    this.RaisePropertyChanged("XppExceptionType");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultMessageList", Namespace="http://schemas.microsoft.com/dynamics/2008/01/documents/Fault")]
    [System.SerializableAttribute()]
    public partial class FaultMessageList : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentOperationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WFConsumo.BoomJournalServRef.FaultMessage[] FaultMessageArrayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FieldField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceOperationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceOperationParameterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XmlLineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XmlPositionField;
        
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
        public string Document {
            get {
                return this.DocumentField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentField, value) != true)) {
                    this.DocumentField = value;
                    this.RaisePropertyChanged("Document");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocumentOperation {
            get {
                return this.DocumentOperationField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentOperationField, value) != true)) {
                    this.DocumentOperationField = value;
                    this.RaisePropertyChanged("DocumentOperation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WFConsumo.BoomJournalServRef.FaultMessage[] FaultMessageArray {
            get {
                return this.FaultMessageArrayField;
            }
            set {
                if ((object.ReferenceEquals(this.FaultMessageArrayField, value) != true)) {
                    this.FaultMessageArrayField = value;
                    this.RaisePropertyChanged("FaultMessageArray");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Field {
            get {
                return this.FieldField;
            }
            set {
                if ((object.ReferenceEquals(this.FieldField, value) != true)) {
                    this.FieldField = value;
                    this.RaisePropertyChanged("Field");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Service {
            get {
                return this.ServiceField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceField, value) != true)) {
                    this.ServiceField = value;
                    this.RaisePropertyChanged("Service");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceOperation {
            get {
                return this.ServiceOperationField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceOperationField, value) != true)) {
                    this.ServiceOperationField = value;
                    this.RaisePropertyChanged("ServiceOperation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ServiceOperationParameter {
            get {
                return this.ServiceOperationParameterField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceOperationParameterField, value) != true)) {
                    this.ServiceOperationParameterField = value;
                    this.RaisePropertyChanged("ServiceOperationParameter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XPath {
            get {
                return this.XPathField;
            }
            set {
                if ((object.ReferenceEquals(this.XPathField, value) != true)) {
                    this.XPathField = value;
                    this.RaisePropertyChanged("XPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XmlLine {
            get {
                return this.XmlLineField;
            }
            set {
                if ((object.ReferenceEquals(this.XmlLineField, value) != true)) {
                    this.XmlLineField = value;
                    this.RaisePropertyChanged("XmlLine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XmlPosition {
            get {
                return this.XmlPositionField;
            }
            set {
                if ((object.ReferenceEquals(this.XmlPositionField, value) != true)) {
                    this.XmlPositionField = value;
                    this.RaisePropertyChanged("XmlPosition");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="InfologMessage", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.Dynamics.AX.Framework.Services")]
    [System.SerializableAttribute()]
    public partial class InfologMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WFConsumo.BoomJournalServRef.InfologMessageType InfologMessageTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public WFConsumo.BoomJournalServRef.InfologMessageType InfologMessageType {
            get {
                return this.InfologMessageTypeField;
            }
            set {
                if ((this.InfologMessageTypeField.Equals(value) != true)) {
                    this.InfologMessageTypeField = value;
                    this.RaisePropertyChanged("InfologMessageType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultMessage", Namespace="http://schemas.microsoft.com/dynamics/2008/01/documents/Fault")]
    [System.SerializableAttribute()]
    public partial class FaultMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="InfologMessageType", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.Dynamics.AX.Framework.Services")]
    public enum InfologMessageType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Info = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Warning = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.microsoft.com/netfx/2009/05/routing", ConfigurationName="BoomJournalServRef.IRequestReplyRouter")]
    public interface IRequestReplyRouter {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRequestReplyRouterChannel : WFConsumo.BoomJournalServRef.IRequestReplyRouter, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RequestReplyRouterClient : System.ServiceModel.ClientBase<WFConsumo.BoomJournalServRef.IRequestReplyRouter>, WFConsumo.BoomJournalServRef.IRequestReplyRouter {
        
        public RequestReplyRouterClient() {
        }
        
        public RequestReplyRouterClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RequestReplyRouterClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RequestReplyRouterClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RequestReplyRouterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.microsoft.com/dynamics/2008/01/services", ConfigurationName="BoomJournalServRef.FTSendXmlBomJournalService")]
    public interface FTSendXmlBomJournalService {
        
        // CODEGEN: Generating message contract since the wrapper name (FTSendXmlBomJournalServiceSendXmlRequest) of message FTSendXmlBomJournalServiceSendXmlRequest does not match the default value (SendXml)
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.microsoft.com/dynamics/2008/01/services/FTSendXmlBomJournalService" +
            "/SendXml", ReplyAction="http://schemas.microsoft.com/dynamics/2008/01/services/FTSendXmlBomJournalService" +
            "/SendXmlResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WFConsumo.BoomJournalServRef.AifFault), Action="http://schemas.microsoft.com/dynamics/2008/01/services/FTSendXmlBomJournalService" +
            "/SendXmlAifFaultFault", Name="AifFault", Namespace="http://schemas.microsoft.com/dynamics/2008/01/documents/Fault")]
        WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlResponse SendXml(WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.microsoft.com/dynamics/2008/01/services/FTSendXmlBomJournalService" +
            "/SendXml", ReplyAction="http://schemas.microsoft.com/dynamics/2008/01/services/FTSendXmlBomJournalService" +
            "/SendXmlResponse")]
        System.Threading.Tasks.Task<WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlResponse> SendXmlAsync(WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FTSendXmlBomJournalServiceSendXmlRequest", WrapperNamespace="http://schemas.microsoft.com/dynamics/2008/01/services", IsWrapped=true)]
    public partial class FTSendXmlBomJournalServiceSendXmlRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://schemas.microsoft.com/dynamics/2010/01/datacontracts")]
        public WFConsumo.BoomJournalServRef.CallContext CallContext;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/dynamics/2008/01/services", Order=0)]
        public string _xmlDocument;
        
        public FTSendXmlBomJournalServiceSendXmlRequest() {
        }
        
        public FTSendXmlBomJournalServiceSendXmlRequest(WFConsumo.BoomJournalServRef.CallContext CallContext, string _xmlDocument) {
            this.CallContext = CallContext;
            this._xmlDocument = _xmlDocument;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FTSendXmlBomJournalServiceSendXmlResponse", WrapperNamespace="http://schemas.microsoft.com/dynamics/2008/01/services", IsWrapped=true)]
    public partial class FTSendXmlBomJournalServiceSendXmlResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/dynamics/2008/01/services", Order=0)]
        public string response;
        
        public FTSendXmlBomJournalServiceSendXmlResponse() {
        }
        
        public FTSendXmlBomJournalServiceSendXmlResponse(string response) {
            this.response = response;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FTSendXmlBomJournalServiceChannel : WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FTSendXmlBomJournalServiceClient : System.ServiceModel.ClientBase<WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService>, WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService {
        
        public FTSendXmlBomJournalServiceClient() {
        }
        
        public FTSendXmlBomJournalServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FTSendXmlBomJournalServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FTSendXmlBomJournalServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FTSendXmlBomJournalServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlResponse WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService.SendXml(WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest request) {
            return base.Channel.SendXml(request);
        }
        
        public string SendXml(WFConsumo.BoomJournalServRef.CallContext CallContext, string _xmlDocument) {
            WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest inValue = new WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest();
            inValue.CallContext = CallContext;
            inValue._xmlDocument = _xmlDocument;
            WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlResponse retVal = ((WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService)(this)).SendXml(inValue);
            return retVal.response;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlResponse> WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService.SendXmlAsync(WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest request) {
            return base.Channel.SendXmlAsync(request);
        }
        
        public System.Threading.Tasks.Task<WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlResponse> SendXmlAsync(WFConsumo.BoomJournalServRef.CallContext CallContext, string _xmlDocument) {
            WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest inValue = new WFConsumo.BoomJournalServRef.FTSendXmlBomJournalServiceSendXmlRequest();
            inValue.CallContext = CallContext;
            inValue._xmlDocument = _xmlDocument;
            return ((WFConsumo.BoomJournalServRef.FTSendXmlBomJournalService)(this)).SendXmlAsync(inValue);
        }
    }
}
