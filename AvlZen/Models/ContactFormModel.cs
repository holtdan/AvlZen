using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvlZen.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public PlacesModel PlacesModel { get; set; }

        public void Init()
        {
            PlacesModel = new PlacesModel();
            PlacesModel.Init();
        }
    }
}
