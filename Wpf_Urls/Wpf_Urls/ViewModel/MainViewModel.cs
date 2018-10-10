using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Urls.Model;

namespace Wpf_Urls.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        /// <summary>
        /// List of url & count url 
        /// </summary>
        private List<DataClass> list;
        public List<DataClass> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                RaisePropertyChanged(() => List);
            }
        }

        /// <summary>
        /// isBusy
        /// </summary>
        private bool busy;
        public bool Busy
        {
            get
            {
                return busy;
            }
            set
            {
                busy = value;
                RaisePropertyChanged(() => Busy);
            }
        }

        /// <summary>
        /// command for load file
        /// </summary>
        private RelayCommand load;
        public RelayCommand Load
        {
            get
            {
                return load ?? (load = new RelayCommand(() => 
                {
                    try
                    {
                        Busy = true;
                        OpenFileDialog od = new OpenFileDialog();
                        od.Multiselect = false;
                        od.ShowDialog();
                        using (Stream stream = od.OpenFile())
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            var str = sr.ReadToEndAsync().Result;
                            string[] url = str.Split(new char[] { '\n' });
                            List<DataClass> data = new List<DataClass>();
                            DataClass.getUrlsCount(url, ref data);
                            List = data;                            
                        } 
                    }
                    catch(Exception ex)
                    {
                        Log.WriteLod(ex.StackTrace);
                    } 
                    finally
                    {
                        Busy = false;
                    }                   
                })); 
            }
        }
    }
}
