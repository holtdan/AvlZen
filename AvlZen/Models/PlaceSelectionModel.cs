using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AvlZen.Models
{
    [DebuggerDisplay("{IsSelected} {PlaceCode}")]
    public class PlaceSelectionModel
    {
        public bool IsSelected { get; set; }
        public string Place { get; set; }
        public string Code { get; set; }
    }
}