using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDebugger.Commands
{
    public static class Runtime
    {
        #region Methods

        /// <summary>
        /// Calls function with given declaration on the given object. Object group of the result is inherited from the target object.
        /// </summary>
        /// <param name="objectId">Identifier of the object to call function on.</param>
        /// <param name="functionDeclaration">Declaration of the function to call.</param>
        /// <param name="arguments">(optional) Call arguments. All call arguments must belong to the same JavaScript world as the target object.</param>
        /// <param name="returnByValue">(optional) Whether the result is expected to be a JSON object which should be sent by value.</param>
        /// <returns>result (RemoteObject): Call result.
        /// wasThrown (optional boolean): True if the result was thrown during the evaluation.</returns>
        public static Command CallFunctionOn(string objectId, string functionDeclaration, CallArgument[] arguments = null, bool returnByValue = false)
        {
            var com = new Command("Runtime.callFunctionOn");
            com.addParam("objectId", objectId);
            com.addParam("functionDeclaration", functionDeclaration);
            if (arguments != null)
            {
                com.addParam("arguments", arguments);
            }
            if (returnByValue)
            {
                com.addParam("returnByValue", returnByValue);
            }
            return com;
        }


        /// <summary>
        /// Evaluates expression on global object.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <param name="objectGroup">(optional) Symbolic group name that can be used to release multiple objects.</param>
        /// <param name="returnByValue">(optional) Whether the result is expected to be a JSON object that should be sent by value.</param>
        /// <returns>result (RemoteObject): Evaluation result.
        /// wasThrown (optional boolean): True if the result was thrown during the evaluation.
        public static Command Evaluate(string expression, string objectGroup = null, bool returnByValue = false)
        {
            var com = new Command("Runtime.evaluate");
            com.addParam("expression", expression);
            com.addParam("objectGroup", objectGroup);
            if (returnByValue)
                com.addParam("returnByValue", returnByValue);
            return com;
        }

        /// <summary>
        /// Returns properties of a given object. Object group of the result is inherited from the target object.
        /// </summary>
        /// <param name="objectId">Identifier of the object to return properties for.</param>
        /// <param name="ownProperties">If true, returns properties belonging only to the element itself, 
        /// not to its prototype chain.</param>
        /// <returns>result (array of PropertyDescriptor): Object properties.</returns>
        public static Command GetProperties(string objectId, bool ownProperties = false)
        {
            var com = new Command("Runtime.getProperties");
            com.addParam("objectId", objectId);
            if (ownProperties)
            {
                com.addParam("ownProperties", ownProperties);
            }
            return com;
        }

        /// <summary>
        /// Releases remote object with given id.
        /// </summary>
        /// <param name="objectId">Identifier of the object to release.</param>
        /// <returns></returns>
        public static Command ReleaseObject(string objectId)
        {
            var com = new Command("Runtime.releaseObject");
            com.addParam("objectId", objectId);
            return com;
        }

        /// <summary>
        /// Releases all remote objects that belong to a given group.
        /// </summary>
        /// <param name="objectGroup">Symbolic object group name.</param>
        /// <returns></returns>
        public static Command ReleaseObjectGroup(string objectGroup)
        {
            var com = new Command("Runtime.releaseObjectGroup");
            com.addParam("objectGroup", objectGroup);
            return com;
        }

        #endregion

        #region Types


        [DataContract]
        public struct RemoteObject
        {
            /// <summary>
            /// Object class (constructor) name. Specified for object type values only.
            /// </summary>
            [DataMember(Name = "className", IsRequired = false)]
            public string ClassName;

            /// <summary>
            /// String representation of the object.
            /// </summary>
            [DataMember(Name = "description", IsRequired = false)]
            public string Description;

            /// <summary>
            /// Unique object identifier (for non-primitive values).
            /// </summary>
            [DataMember(Name = "objectId", IsRequired = false)]
            public string ObjectId;

            /// <summary>
            /// enumerated string [ "array" , "date" , "node" , "null" , "regexp" ]. Object subtype hint. Specified for object type values only.
            /// </summary>
            [DataMember(Name = "subtype", IsRequired = false)]
            public string Subtype;

            /// <summary>
            /// enumerated string [ "boolean" , "function" , "number" , "object" , "string" , "undefined" ]. Object type.
            /// </summary>
            [DataMember(Name = "type")]
            public string Type;

            /// <summary>
            /// Remote object value (in case of primitive values or JSON values if it was requested).
            /// </summary>
            [DataMember(Name = "value")]
            public object Value;
        }

        [DataContract]
        public struct CallArgument
        {
            /// <summary>
            /// Remote object handle.
            /// </summary>
            [DataMember(Name = "objectId")]
            public string ObjectId;

            /// <summary>
            /// Primitive value.
            /// </summary>
            [DataMember(Name = "value")]
            public object Value;
        }

        [DataContract]
        public struct PropertyDescriptor
        {

            /// <summary>
            /// True if the type of this property descriptor may be changed and if the property may be deleted from the corresponding object.
            /// </summary>
            [DataMember(Name = "configurable")]
            public bool Configurable;

            /// <summary>
            /// True if this property shows up during enumeration of the properties on the corresponding object.
            /// </summary>
            [DataMember(Name = "enumerable")]
            public bool Enumerable;

            /// <summary>
            /// A function which serves as a getter for the property, or undefined if there is no getter (accessor descriptors only).
            /// </summary>
            [DataMember(Name = "get", IsRequired = false)]
            public RemoteObject Get;

            /// <summary>
            /// Property name.
            /// </summary>
            [DataMember(Name = "name")]
            public string Name;

            /// <summary>
            /// A function which serves as a setter for the property, or undefined if there is no setter (accessor descriptors only).
            /// </summary>
            [DataMember(Name = "set", IsRequired = false)]
            public RemoteObject Set;

            /// <summary>
            /// The value associated with the property.
            /// </summary>
            [DataMember(Name = "value", IsRequired = false)]
            public RemoteObject Value;

            /// <summary>
            /// True if the result was thrown during the evaluation.
            /// </summary>
            [DataMember(Name = "wasThrown", IsRequired = false)]
            public bool? WasThrown;

            /// <summary>
            /// True if the value associated with the property may be changed (data descriptors only).
            /// </summary>
            [DataMember(Name = "writable", IsRequired = false)]
            public bool? Writable;
        }

        #endregion
    }
}
