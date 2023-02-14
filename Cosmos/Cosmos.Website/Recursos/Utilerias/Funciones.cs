using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cosmos.Framework;
using DevExpress.Web;

namespace Cosmos.Website.Recursos.Utilerias
{
    public class Funciones
    {

        public static void SetControlValue(ref ASPxComboBox typedControl, int value)
        {
            String r = "";
            if (typedControl != null)
            {                                
                typedControl.SelectedItem = typedControl.Items.FindByValue(value);                
            }
        }
        public static void SetControlValue(ref ASPxTextBox typedControl, string value)
        {
            string r = "";
            if (typedControl != null)
            {
                typedControl.Text = CastHelper.CStr2(value);
            }
        }

        public static void SetControlValue(ref ASPxDateEdit typedControl, DateTime value)
        {
            DateTime r = new DateTime(1900, 1, 1);
            if (value < r) { value = r; }
            if (typedControl != null)
            {
                if (typedControl.Date != null)
                {
                    typedControl.Date = value;
                }
            }
        }

        public static void SetControlValue(ref ASPxCheckBox typedControl, bool value)
        {
            if (typedControl != null)
            {
                typedControl.Checked = value;
            }
        }

        public static void SetControlValue(ref ASPxGridLookup typedControl, int value)
        {
            if (typedControl != null)
            {
                typedControl.Value = value;
            }
        }

        public static int GetControlValue(ASPxComboBox typedControl) {
            String r = "";
            if (typedControl != null)
            {
                if (typedControl.SelectedItem != null)
                {
                    r = CastHelper.CStr2(typedControl.SelectedItem.Value);
                }
                else
                {
                    if (typedControl.Value != null) { r = CastHelper.CStr2(typedControl.Value); }
                }
            }
            return CastHelper.CInt2(r);
        }

        public static string GetControlValue(ASPxTextBox typedControl)
        {
            string r = "";
            if (typedControl != null) {
                r = CastHelper.CStr2(typedControl.Text);
            }
            return r;
        }

        public static string GetControlValue(ASPxHiddenField typedControl, string keyName)
        {
            string r = "";
            if (typedControl != null)
            {

                try
                {
                    r = CastHelper.CStr2(typedControl[keyName]);
                }
                catch (Exception ex) {
                    r = "";
                }
            }
            return r;
        }

        public static DateTime GetControlValue(ASPxDateEdit typedControl)
        {
            DateTime r = new DateTime(1900,1,1);
            if (typedControl != null)
            {
                if (typedControl.Date != null) {
                    if (typedControl.Date > r) {
                        r = typedControl.Date;
                    }                    
                }                
            }
            return r;
        }

        public static bool GetControlValue(ASPxCheckBox typedControl)
        {
            bool r = false;
            if (typedControl != null)
            {
                r = typedControl.Checked;
            }
            return r;
        }

        public static int GetControlValue(ASPxGridLookup typedControl)
        {
            int r = 0;
            if (typedControl != null)
            {
                if (typedControl.Value != null)
                {
                    r = CastHelper.CInt2(typedControl.Value);
                }
            }
            return r;
        }

        public static string ValorControlX(object ctrl) {
            String r = "";
            if (ctrl != null)
            {
                if (ctrl.GetType() == typeof(ASPxComboBox))
                {
                    ASPxComboBox typedControl = (ASPxComboBox)ctrl;
                    if (typedControl.SelectedItem != null)
                    {
                        r = CastHelper.CStr2(typedControl.SelectedItem.Value);
                    }
                    else
                    {
                        if (typedControl.Value != null) { r = CastHelper.CStr2(typedControl.Value); }
                    }
                }
                else if (ctrl.GetType() == typeof(ASPxTextBox))
                {
                    ASPxTextBox typedControl = (ASPxTextBox)ctrl;
                    r = CastHelper.CStr2(typedControl.Text);
                }
                else if (ctrl.GetType() == typeof(ASPxGridLookup))
                {
                    ASPxGridLookup typedControl = (ASPxGridLookup)ctrl;
                    if (typedControl.Value != null){
                        r = CastHelper.CStr2(typedControl.Value);
                    }                    
                }
                else if (ctrl.GetType() == typeof(ASPxCheckBox))
                {
                    ASPxCheckBox typedControl = (ASPxCheckBox)ctrl;
                    if (typedControl.Checked) {
                        r = "1";
                    }
                    else {
                        r = "0";
                    }
                }
            }
            return r;
        }
    }
}