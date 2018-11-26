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

    public partial class ServiceCategoryFormsApi
    {
        /// <summary>
        /// Initializes a new instance of the ServiceCategoryFormsApi class.
        /// </summary>
        public ServiceCategoryFormsApi() { }

        /// <summary>
        /// Initializes a new instance of the ServiceCategoryFormsApi class.
        /// </summary>
        public ServiceCategoryFormsApi(long? serviceCategoryId = default(long?), IList<ServiceCategoryForm> forms = default(IList<ServiceCategoryForm>), string name = default(string))
        {
            ServiceCategoryId = serviceCategoryId;
            Forms = forms;
            Name = name;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ServiceCategoryId")]
        public long? ServiceCategoryId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Forms")]
        public IList<ServiceCategoryForm> Forms { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

    }
}
