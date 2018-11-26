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

    public partial class EventCreateModel
    {
        /// <summary>
        /// Initializes a new instance of the EventCreateModel class.
        /// </summary>
        public EventCreateModel() { }

        /// <summary>
        /// Initializes a new instance of the EventCreateModel class.
        /// </summary>
        public EventCreateModel(string eventName = default(string), string description = default(string), DateTime? eventDate = default(DateTime?), DateTime? eventEndDate = default(DateTime?), bool? isPublic = default(bool?), int? days = default(int?), int? weeks = default(int?), int? months = default(int?), int? years = default(int?), int? numOfPeople = default(int?), string startTime = default(string), string endTime = default(string), string setupStartTime = default(string), string tearDownEndTime = default(string), string hvacStartTime = default(string), string hvacEndTime = default(string), int? heatPoint = default(int?), int? coolPoint = default(int?), bool? noHvac = default(bool?), bool? isAllDayEvent = default(bool?), bool? isMultiDayEvent = default(bool?), EventRecurrenceCriteria eventRecurrenceCriteria = default(EventRecurrenceCriteria), IList<SelectListItem> reminderDaysOptions = default(IList<SelectListItem>), IList<int?> reminderRecipientTypes = default(IList<int?>), int? alertDurationInDays = default(int?), int? customAlertDurationInDays = default(int?), string reminderNotes = default(string), string recurrenceTypeId = default(string), string dailyRecurrence = default(string), string monthlyRecurrence = default(string), string yearlyRecurrence = default(string), bool? isSunday = default(bool?), bool? isMonday = default(bool?), bool? isTuesday = default(bool?), bool? isWednesday = default(bool?), bool? isThursday = default(bool?), bool? isFriday = default(bool?), bool? isSaturday = default(bool?), IList<int?> weekDays = default(IList<int?>), IList<long?> categories = default(IList<long?>), int? dayXOfMonth = default(int?), int? xthDayOfWeekOfMonth = default(int?), int? dayXOfMonthDay = default(int?), bool? autoApprove = default(bool?), int? yearlyXthDayOfWeekOfMonth = default(int?), int? yearlyXthDayOfWeekOfMonthDayOfWeek = default(int?), int? status = default(int?), long? ownerId = default(long?), bool? addContacts = default(bool?), string publicNotes = default(string), string publicLink = default(string), bool? beReminded = default(bool?), IList<long?> locations = default(IList<long?>), IList<long?> publicLocations = default(IList<long?>), bool? isOffSite = default(bool?), string offsiteLocation = default(string), IList<long?> editorIds = default(IList<long?>), long? scheduleId = default(long?), long? eventId = default(long?), string scheduleName = default(string))
        {
            EventName = eventName;
            Description = description;
            EventDate = eventDate;
            EventEndDate = eventEndDate;
            IsPublic = isPublic;
            Days = days;
            Weeks = weeks;
            Months = months;
            Years = years;
            NumOfPeople = numOfPeople;
            StartTime = startTime;
            EndTime = endTime;
            SetupStartTime = setupStartTime;
            TearDownEndTime = tearDownEndTime;
            HvacStartTime = hvacStartTime;
            HvacEndTime = hvacEndTime;
            HeatPoint = heatPoint;
            CoolPoint = coolPoint;
            NoHvac = noHvac;
            IsAllDayEvent = isAllDayEvent;
            IsMultiDayEvent = isMultiDayEvent;
            EventRecurrenceCriteria = eventRecurrenceCriteria;
            ReminderDaysOptions = reminderDaysOptions;
            ReminderRecipientTypes = reminderRecipientTypes;
            AlertDurationInDays = alertDurationInDays;
            CustomAlertDurationInDays = customAlertDurationInDays;
            ReminderNotes = reminderNotes;
            RecurrenceTypeId = recurrenceTypeId;
            DailyRecurrence = dailyRecurrence;
            MonthlyRecurrence = monthlyRecurrence;
            YearlyRecurrence = yearlyRecurrence;
            IsSunday = isSunday;
            IsMonday = isMonday;
            IsTuesday = isTuesday;
            IsWednesday = isWednesday;
            IsThursday = isThursday;
            IsFriday = isFriday;
            IsSaturday = isSaturday;
            WeekDays = weekDays;
            Categories = categories;
            DayXOfMonth = dayXOfMonth;
            XthDayOfWeekOfMonth = xthDayOfWeekOfMonth;
            DayXOfMonthDay = dayXOfMonthDay;
            AutoApprove = autoApprove;
            YearlyXthDayOfWeekOfMonth = yearlyXthDayOfWeekOfMonth;
            YearlyXthDayOfWeekOfMonthDayOfWeek = yearlyXthDayOfWeekOfMonthDayOfWeek;
            Status = status;
            OwnerId = ownerId;
            AddContacts = addContacts;
            PublicNotes = publicNotes;
            PublicLink = publicLink;
            BeReminded = beReminded;
            Locations = locations;
            PublicLocations = publicLocations;
            IsOffSite = isOffSite;
            OffsiteLocation = offsiteLocation;
            EditorIds = editorIds;
            ScheduleId = scheduleId;
            EventId = eventId;
            ScheduleName = scheduleName;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventName")]
        public string EventName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventDate")]
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EventEndDate")]
        public DateTime? EventEndDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsPublic")]
        public bool? IsPublic { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Days")]
        public int? Days { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Weeks")]
        public int? Weeks { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Months")]
        public int? Months { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Years")]
        public int? Years { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NumOfPeople")]
        public int? NumOfPeople { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StartTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EndTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "SetupStartTime")]
        public string SetupStartTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TearDownEndTime")]
        public string TearDownEndTime { get; set; }

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
        [JsonProperty(PropertyName = "NoHvac")]
        public bool? NoHvac { get; set; }

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
        [JsonProperty(PropertyName = "EventRecurrenceCriteria")]
        public EventRecurrenceCriteria EventRecurrenceCriteria { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ReminderDaysOptions")]
        public IList<SelectListItem> ReminderDaysOptions { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ReminderRecipientTypes")]
        public IList<int?> ReminderRecipientTypes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AlertDurationInDays")]
        public int? AlertDurationInDays { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CustomAlertDurationInDays")]
        public int? CustomAlertDurationInDays { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ReminderNotes")]
        public string ReminderNotes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RecurrenceTypeId")]
        public string RecurrenceTypeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DailyRecurrence")]
        public string DailyRecurrence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonthlyRecurrence")]
        public string MonthlyRecurrence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "YearlyRecurrence")]
        public string YearlyRecurrence { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsSunday")]
        public bool? IsSunday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsMonday")]
        public bool? IsMonday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsTuesday")]
        public bool? IsTuesday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsWednesday")]
        public bool? IsWednesday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsThursday")]
        public bool? IsThursday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsFriday")]
        public bool? IsFriday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsSaturday")]
        public bool? IsSaturday { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "WeekDays")]
        public IList<int?> WeekDays { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Categories")]
        public IList<long?> Categories { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DayXOfMonth")]
        public int? DayXOfMonth { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "XthDayOfWeekOfMonth")]
        public int? XthDayOfWeekOfMonth { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DayXOfMonthDay")]
        public int? DayXOfMonthDay { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AutoApprove")]
        public bool? AutoApprove { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "YearlyXthDayOfWeekOfMonth")]
        public int? YearlyXthDayOfWeekOfMonth { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "YearlyXthDayOfWeekOfMonthDayOfWeek")]
        public int? YearlyXthDayOfWeekOfMonthDayOfWeek { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Status")]
        public int? Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OwnerId")]
        public long? OwnerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AddContacts")]
        public bool? AddContacts { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PublicNotes")]
        public string PublicNotes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PublicLink")]
        public string PublicLink { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BeReminded")]
        public bool? BeReminded { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Locations")]
        public IList<long?> Locations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PublicLocations")]
        public IList<long?> PublicLocations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsOffSite")]
        public bool? IsOffSite { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OffsiteLocation")]
        public string OffsiteLocation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EditorIds")]
        public IList<long?> EditorIds { get; set; }

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

    }
}
