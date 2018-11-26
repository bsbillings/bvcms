﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ESpace.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class ServiceCategoryForm
    {
        /// <summary>
        /// Initializes a new instance of the ServiceCategoryForm class.
        /// </summary>
        public ServiceCategoryForm() { }

        /// <summary>
        /// Initializes a new instance of the ServiceCategoryForm class.
        /// </summary>
        public ServiceCategoryForm(string formName = default(string), long? formVersionId = default(long?), bool? isEditable = default(bool?), IList<FormBuilderQuestion> questions = default(IList<FormBuilderQuestion>))
        {
            FormName = formName;
            FormVersionId = formVersionId;
            IsEditable = isEditable;
            Questions = questions;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FormName")]
        public string FormName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FormVersionId")]
        public long? FormVersionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsEditable")]
        public bool? IsEditable { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Questions")]
        public IList<FormBuilderQuestion> Questions { get; set; }

    }
}
