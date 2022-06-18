using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Xml;
namespace CPU_Monitor.Model
{
    internal class Settings
    {
        private string settings_file_path = "./settings.xml";
        private Boolean load_at_startup;
        private Boolean display_cpu;
        private Boolean display_gpu;
        private Boolean display_using;
        private Boolean display_temp;
        public Settings()
        {
            this.readLastSettings();
        }
        public Boolean getLoadAtStartup()
        {
            return this.load_at_startup;
        }
        public Boolean getDisplayCPU()
        {
            return this.display_cpu;
        }
        public Boolean getDisplayGPU()
        {
            return this.display_gpu;
        }
        public Boolean getDisplayUsing()
        {
            return this.display_using;
        }
        public Boolean getDisplayTemp()
        {
            return this.display_temp;
        }
        public void setLoadAtStartup(Boolean is_enable)
        {
            this.load_at_startup = is_enable;
        }
        public void setDisplayCPU(Boolean is_enable)
        {
            this.display_cpu = is_enable;
        }
        public void setDisplayGPU(Boolean is_enable)
        {
            this.display_gpu = is_enable;
        }
        public void setDisplayTemp(Boolean is_enable)
        {
            if (!is_enable && !this.display_using)
            {
                this.errorMessage();
            }
            else
            {
                this.display_temp = is_enable;
            }
        }
        public void setDisplayUsing(Boolean is_enable)
        {
            if (!is_enable && !this.display_temp)
            {
                this.errorMessage();
            }
            else
            {
                this.display_using = is_enable;
            }
            this.display_using = is_enable;
        }
        private async void errorMessage()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Error",
                Content = "At least one of the settings \"Show temperature\" or \"Show using\" must be selected",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await dialog.ShowAsync();
        }
        public void saveSettings()
        {
            BoolToString booltostring = new BoolToString();
            XmlTextWriter xml_file = new XmlTextWriter("./settings.xml", Encoding.UTF8);
            xml_file.WriteStartDocument();
            xml_file.WriteStartElement("settings");
            xml_file.WriteStartElement("load_at_startup");
            xml_file.WriteString(booltostring.convert(this.load_at_startup));
            xml_file.WriteEndElement();
            xml_file.WriteStartElement("display_cpu");
            xml_file.WriteString(booltostring.convert(this.display_cpu));
            xml_file.WriteEndElement();
            xml_file.WriteStartElement("display_gpu");
            xml_file.WriteString(booltostring.convert(this.display_gpu));
            xml_file.WriteEndElement();
            xml_file.WriteStartElement("display_using");
            xml_file.WriteString(booltostring.convert(this.display_using));
            xml_file.WriteEndElement();
            xml_file.WriteStartElement("display_temp");
            xml_file.WriteString(booltostring.convert(this.display_temp));
            xml_file.WriteEndDocument();
            xml_file.Close();
        }
        public void readLastSettings()
        {
            StringToBool string_to_bool = new StringToBool();
            if (!File.Exists(this.settings_file_path))
            {
                this.setDefaultSettings();
                this.saveSettings();

            }
            XmlReader xml_file = XmlReader.Create(this.settings_file_path);
            while (xml_file.ReadToFollowing("settings"))
            {
                xml_file.ReadToFollowing("load_at_startup");
                this.load_at_startup = string_to_bool.convert(xml_file.ReadElementContentAsString());
                xml_file.ReadToFollowing("display_cpu");
                this.display_cpu = string_to_bool.convert(xml_file.ReadElementContentAsString());
                xml_file.ReadToFollowing("display_gpu");
                this.display_gpu = string_to_bool.convert(xml_file.ReadElementContentAsString());
                xml_file.ReadToFollowing("display_using");
                this.display_using = string_to_bool.convert(xml_file.ReadElementContentAsString());
                xml_file.ReadToFollowing("display_temp");
                this.display_temp = string_to_bool.convert(xml_file.ReadElementContentAsString());
            }
        }
        public void setDefaultSettings()
        {
            this.load_at_startup = false;
            this.display_cpu = true;
            this.display_gpu = false;
            this.display_using = true;
            this.display_temp = true;
        }
    }
}
