using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CPU_Monitor.Model
{
    internal class Settings
    {
        private Boolean load_at_startup;
        private Boolean display_cpu;
        private Boolean display_gpu;
        private Boolean display_using;
        private Boolean display_temp;
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
    }
}
