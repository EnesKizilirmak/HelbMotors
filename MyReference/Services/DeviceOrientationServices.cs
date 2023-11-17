using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReference.Services
{
    public partial class DeviceOrientationServices //Doit être partial car le contenu sera défini dans des dossiers spécifiques suivant la plateforme (mobile, pc, etc.)
    {
        public DeviceOrientationServices() { }

        public partial void ConfigureScanner(); //Doit être partial
    }
}
