﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Touchpoint.Cms.Integrations.ESpace.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class CommentInfo
    {
        /// <summary>
        /// Initializes a new instance of the CommentInfo class.
        /// </summary>
        public CommentInfo() { }

        /// <summary>
        /// Initializes a new instance of the CommentInfo class.
        /// </summary>
        public CommentInfo(string comment, long? id = default(long?), string dateCreatedDisplay = default(string), DateTime? dateCreated = default(DateTime?), string commenter = default(string), long? workOrderId = default(long?), long? leadId = default(long?), string timeZone = default(string))
        {
            Id = id;
            Comment = comment;
            DateCreatedDisplay = dateCreatedDisplay;
            DateCreated = dateCreated;
            Commenter = commenter;
            WorkOrderId = workOrderId;
            LeadId = leadId;
            TimeZone = timeZone;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Comment")]
        public string Comment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DateCreatedDisplay")]
        public string DateCreatedDisplay { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DateCreated")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Commenter")]
        public string Commenter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "WorkOrderId")]
        public long? WorkOrderId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LeadId")]
        public long? LeadId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TimeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Comment == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Comment");
            }
        }
    }
}
