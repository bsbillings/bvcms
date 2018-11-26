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

    public partial class SelectListItem
    {
        /// <summary>
        /// Initializes a new instance of the SelectListItem class.
        /// </summary>
        public SelectListItem() { }

        /// <summary>
        /// Initializes a new instance of the SelectListItem class.
        /// </summary>
        public SelectListItem(bool? disabled = default(bool?), SelectListGroup group = default(SelectListGroup), bool? selected = default(bool?), string text = default(string), string value = default(string))
        {
            Disabled = disabled;
            Group = group;
            Selected = selected;
            Text = text;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Group")]
        public SelectListGroup Group { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Selected")]
        public bool? Selected { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

    }
}
