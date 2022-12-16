using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace PuntoDeVenta.src
{
    public class Temas
    {
        public ResourceDictionary CargarTema()
        {
            string tema = Properties.Settings.Default.Tema;
            ResourceDictionary resDic;
            if(tema == null)
            {
                tema = "Green";
                Properties.Settings.Default.Save();
            }
            string ubicacion = $"src/Themes/{tema}.xaml";

            if (File.Exists(@"" + tema + ".xaml"))
            {
                resDic = new ResourceDictionary
                {
                    Source = new Uri(ubicacion, UriKind.Relative)
                };
            }
            else
            {
                resDic = new ResourceDictionary
                {
                    Source = new Uri(ubicacion, UriKind.Relative)
                };

                var settings = new System.Xml.XmlWriterSettings();
                settings.Indent = true;
                var writer = System.Xml.XmlWriter.Create(@"" + tema + ".xaml", settings);
                XamlWriter.Save(resDic, writer);
            }

            return resDic;
        }
    }
}
