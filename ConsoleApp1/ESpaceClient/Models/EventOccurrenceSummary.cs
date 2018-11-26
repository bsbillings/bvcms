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

    public partial class EventOccurrenceSummary
    {
        /// <summary>
        /// Initializes a new instance of the EventOccurrenceSummary class.
        /// </summary>
        public EventOccurrenceSummary() { }

        /// <summary>
        /// Initializes a new instance of the EventOccurrenceSummary class.
        /// </summary>
        public EventOccurrenceSummary(long? occurrenceId = default(long?), string name = default(string), DateTime? eventStart = default(DateTime?), DateTime? eventEnd = default(DateTime?), long? eventId = default(long?), string spaces = default(string), bool? isPublic = default(bool?), string locations = default(string), string description = default(string), string categories = default(string), string status = default(string))
        {
            OccurrenceId = occurrenceId;
            Name = name;
            EventStart = eventStart;
            EventEnd = eventEnd;
            EventId = eventId;
            Spaces = spaces;
            IsPublic = isPublic;
            Locations = locations;
            Description = description;
            Categories = categories;
            Status = status;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OccurrenceId")]
        public long? OccurrenceId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventStart")]
        public DateTime? EventStart { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventEnd")]
        public DateTime? EventEnd { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventId")]
        public long? EventId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Spaces")]
        public string Spaces { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsPublic")]
        public bool? IsPublic { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Locations")]
        public string Locations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Categories")]
        public string Categories { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

    }
}
