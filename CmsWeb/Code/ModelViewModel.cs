﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using CmsData;
using UtilityExtensions;

namespace CmsWeb.Code
{
    public class TrackChangesAttribute : Attribute { }
    public class PhoneAttribute : Attribute { }
    public class NoUpdate : Attribute { }
    public class SkipField : Attribute { }

    public class FieldInfoAttribute : Attribute
    {
        public string IdField { get; set; }
        public string CheckboxField { get; set; }
    }

    public interface IModelViewModelObject
    {
        string CopyToModel(PropertyInfo vm, object model, PropertyInfo[] modelProps);
        void CopyFromModel(PropertyInfo vm, object model, PropertyInfo[] modelProps);
    }

    public static class ModelViewModel
    {
        public static void CopyPropertiesFrom(this object viewmodel, object model, string onlyfields = "", string excludefields = "")
        {
            var cv = new CodeValueModel();
            var modelProps = model.GetType().GetProperties();
            var viewmodelProps = viewmodel.GetType().GetProperties();
            var only = onlyfields.Split(',');
            var exclude = excludefields.Split(',');

            foreach (var vm in viewmodelProps)
            {
                if (onlyfields.HasValue() && !only.Contains(vm.Name))
                    continue;
                if (excludefields.HasValue() && exclude.Contains(vm.Name))
                    continue;
                if (vm.HasAttribute<SkipField>())
                    continue;

                if(typeof(IModelViewModelObject).IsAssignableFrom(vm.PropertyType))
                {
                    var ivm = Activator.CreateInstance(vm.PropertyType);
                    ((IModelViewModelObject)ivm).CopyFromModel(vm, model, modelProps);
                    vm.SetValue(viewmodel, ivm, null);
                    continue;
                }
                // find a model property of the same name as viewmodel
                var m = modelProps.FirstOrDefault(mm => mm.Name == vm.Name);

                if (m == null)
                    continue;

                // get the model value we are going to copy
                var modelvalue = m.GetValue(model, null);

                if (vm.HasAttribute<PhoneAttribute>())
                    vm.SetPropertyFromText(viewmodel, ((string) modelvalue).FmtFone());

                    // if they are the same type, then straight copy

                else if (m.PropertyType == vm.PropertyType)
                    vm.SetValue(viewmodel, modelvalue, null);

                else if (modelvalue is string)
                    vm.SetPropertyFromText(viewmodel, (string) modelvalue);

                else if (modelvalue is DateTime && (DateTime) modelvalue == ((DateTime) modelvalue).Date)
                    vm.SetPropertyFromText(viewmodel, ((DateTime) modelvalue).ToShortDateString());

                else // Handle any other type mismatches like int = Nullable<int> or vice-versa
                    vm.SetPropertyFromText(viewmodel, (modelvalue ?? "").ToString());
            }
        }
        public static string CopyPropertiesTo(this object viewmodel, object model, string onlyfields = "", string excludefields = "")
        {
            var modelProps = model.GetType().GetProperties();
            var viewmodelProps = viewmodel.GetType().GetProperties();
            var changes = new StringBuilder();
            var only = onlyfields.Split(',');
            var exclude = excludefields.Split(',');

            foreach (var vm in viewmodelProps)
            {
                if (onlyfields.HasValue() && !only.Contains(vm.Name))
                    continue;
                if (excludefields.HasValue() && exclude.Contains(vm.Name))
                    continue;
                if (vm.HasAttribute<NoUpdate>())
                    continue;

                // get the viewmodel value we are going to copy
                var viewmodelvalue = vm.GetValue(viewmodel, null);

                if (viewmodelvalue is IModelViewModelObject)
                {
                    var ivm = viewmodelvalue as IModelViewModelObject;
                    changes.Append(ivm.CopyToModel(vm, model, modelProps));
                    continue;
                }

                var track = Attribute.IsDefined(vm, typeof(TrackChangesAttribute));

                // find a target property of the same name as source
                var m = modelProps.FirstOrDefault(mm => mm.Name == vm.Name);

                if (m == null)
                    continue;

                if (vm.HasAttribute<PhoneAttribute>())
                {
                    var ph = ((string)viewmodelvalue).GetDigits();
                    if (track)
                        model.UpdateValue(changes, m.Name, ph);
                    else
                        m.SetPropertyFromText(model, ph);
                    vm.SetValue(viewmodel, ph.FmtFone(), null);
                }

                // if they are the same type, then straight copy
                else if (m.PropertyType == vm.PropertyType)
                    if (track)
                        model.UpdateValue(changes, m.Name, viewmodelvalue);
                    else
                        m.SetValue(model, viewmodelvalue, null);

                else if (viewmodelvalue is string)
                    if (track)
                        model.UpdateValue(changes, m.Name, viewmodelvalue);
                    else
                        m.SetPropertyFromText(model, (string)viewmodelvalue);

                else // Handle any other type mismatches like int = Nullable<int> or vice-versa
                    if (track)
                        model.UpdateValue(changes, m.Name, viewmodelvalue);
                    else
                        m.SetPropertyFromText(model, (viewmodelvalue ?? "").ToString());
            }
            return changes.ToString();
        }

        public static SelectList ToSelect(this IEnumerable<CodeValueItem> items, string datafield = "Id")
        {
            if (items == null)
                throw new Exception("items are null in SelectList");
            return new SelectList(items, datafield, "Value");
        }
        public static IEnumerable<CodeValueItem> AddNotSpecified(this IEnumerable<CodeValueItem> q)
        {
            return q.AddNotSpecified(0);
        }
        public static IEnumerable<CodeValueItem> AddNotSpecified(this IEnumerable<CodeValueItem> q, int value)
        {
            var list = q.ToList();
            list.Insert(0, new CodeValueItem { Id = value, Code = value.ToString(), Value = "(not specified)" });
            return list;
        }

        public static bool HasAttribute<T>(this PropertyInfo a)
        {
            return Attribute.IsDefined(a, typeof(T));
        }

        public static T GetAttribute<T>(this PropertyInfo a)
        {
            return a.GetCustomAttributes(true).OfType<T>().SingleOrDefault();
        }
    }
}