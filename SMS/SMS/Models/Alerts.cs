using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Alerts
    {

        public static AlertsType AlertType { get; set; }
        public static string AlertText { get; set; }

        public static void ShowAlerts(AlertsType AlertsType, string AlertsText)
        {
            Alerts.AlertType = AlertsType;
            Alerts.AlertText = AlertsText;
        }
    }

    public enum AlertsType
    {
        None,
        Deleted,
        Saved,
        Updated,
        Error
    }
}