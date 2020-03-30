using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.XrmToolBox
{
    public class DependencyItem // : EntityReference
    {
        private string _recordUrl = null;
        private string _baseServerUrl = null;

        /// <summary>
        /// Initializes a new instance of the Microsoft.Xrm.Sdk.EntityReference class setting
        /// the logical name and entity ID. This constructor was introduced with Microsoft
        /// Dynamics CRM Online 2015 Update 1 and cannot be used with earlier versions.
        /// </summary>
        /// <param name="logicalName">The logical name of the entity.</param>
        /// <param name="id">The ID of the record.</param>
        public DependencyItem(string logicalName, Guid id, string baseServerUrl)
        {
            Id = id;
            LogicalName = logicalName;
            _baseServerUrl = baseServerUrl;
        }

        /// <summary>
        /// Gets or sets the ID of the record.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the logical name of the target entity.
        /// </summary>
        public string LogicalName { get; set; }

        /// <summary>
        /// Gets or sets the logical name of the target entity.
        /// </summary>
        public string DisplayName { get; set; }


        /// <summary>
        /// Gets or sets the value of the primary attribute of the entity.
        /// </summary>
        public string RecordPrimaryField { get; set; }

        /// <summary>
        /// Gets or sets the Details of the dependency
        /// </summary>
        public string DependencySummary { get; set; }

        /// <summary>
        /// List of the values searched for and where found
        /// </summary>
        public List<FindResult> FindResults { get; set; } = new List<FindResult>();

        /// <summary>
        /// URL for the current item
        /// </summary>
        public string EntityReferenceUrl
        {
            get {
                if (_recordUrl == null)
                {
                    if (!string.IsNullOrEmpty(LogicalName) && !Id.Equals(Guid.Empty))
                    {
                        _recordUrl = string.Concat(_baseServerUrl,
                            _baseServerUrl.EndsWith("/") ? "" : "/",
                            "main.aspx?etn=",
                            LogicalName,
                            "&pagetype=entityrecord&id=",
                            Id.ToString());
                    }
                }
                return _recordUrl;
            }
        }

    }

    /// <summary>
    /// Helper class to capture where the attribute was found 
    /// </summary>
    public class FindResult
    {
        /// <summary>
        /// Value being searched for
        /// </summary>
        public List<string> SearchValues { get; set; }

        /// <summary>
        /// Gets or sets the name of the Attribute where the dependency was found 
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// Gets or sets the Value of the Attribute where the dependency was found 
        /// </summary>
        public string AttributeValue { get; set; }

        public override string ToString()
        {
            return $"Search Item(s):'{String.Join("','", SearchValues)}'{Environment.NewLine}" +
                $"Attribute: '{AttributeName}'{Environment.NewLine}" +
                $"Value: {AttributeValue}";
        }
    }
}
