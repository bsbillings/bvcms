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

    public partial class AddOccurrenceModel
    {
        /// <summary>
        /// Initializes a new instance of the AddOccurrenceModel class.
        /// </summary>
        public AddOccurrenceModel() { }

        /// <summary>
        /// Initializes a new instance of the AddOccurrenceModel class.
        /// </summary>
        public AddOccurrenceModel(long? scheduleId = default(long?), long? eventId = default(long?), string scheduleName = default(string), DateTime? eventStartDate = default(DateTime?), DateTime? setup = default(DateTime?), DateTime? teardown = default(DateTime?), DateTime? startTime = default(DateTime?), DateTime? endTime = default(DateTime?), bool? isAllDayEvent = default(bool?), bool? isMultiDayEvent = default(bool?), DateTime? eventEndDate = default(DateTime?), bool? isCoolSpaceClient = default(bool?), bool? isEntouchClient = default(bool?), bool? isAdmin = default(bool?), bool? noHvac = default(bool?), string hvacStartTime = default(string), string hvacEndTime = default(string), int? heatPoint = default(int?), int? coolPoint = default(int?), long? occurrenceId = default(long?))
        {
            ScheduleId = scheduleId;
            EventId = eventId;
            ScheduleName = scheduleName;
            EventStartDate = eventStartDate;
            Setup = setup;
            Teardown = teardown;
            StartTime = startTime;
            EndTime = endTime;
            IsAllDayEvent = isAllDayEvent;
            IsMultiDayEvent = isMultiDayEvent;
            EventEndDate = eventEndDate;
            IsCoolSpaceClient = isCoolSpaceClient;
            IsEntouchClient = isEntouchClient;
            IsAdmin = isAdmin;
            NoHvac = noHvac;
            HvacStartTime = hvacStartTime;
            HvacEndTime = hvacEndTime;
            HeatPoint = heatPoint;
            CoolPoint = coolPoint;
            OccurrenceId = occurrenceId;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduleId")]
        public long? ScheduleId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventId")]
        public long? EventId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ScheduleName")]
        public string ScheduleName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventStartDate")]
        public DateTime? EventStartDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Setup")]
        public DateTime? Setup { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Teardown")]
        public DateTime? Teardown { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StartTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EndTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsAllDayEvent")]
        public bool? IsAllDayEvent { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsMultiDayEvent")]
        public bool? IsMultiDayEvent { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventEndDate")]
        public DateTime? EventEndDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsCoolSpaceClient")]
        public bool? IsCoolSpaceClient { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsEntouchClient")]
        public bool? IsEntouchClient { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsAdmin")]
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NoHvac")]
        public bool? NoHvac { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "HvacStartTime")]
        public string HvacStartTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "HvacEndTime")]
        public string HvacEndTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "HeatPoint")]
        public int? HeatPoint { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CoolPoint")]
        public int? CoolPoint { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OccurrenceId")]
        public long? OccurrenceId { get; set; }

    }
}
