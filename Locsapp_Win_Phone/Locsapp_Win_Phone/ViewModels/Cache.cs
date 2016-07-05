using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locsapp_Win_Phone.Models;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;


namespace Locsapp_Win_Phone.ViewModels
{
    class Cache
    {
        public async Task<bool> Save(string file, Dictionary<string, string> data)
        {
            try
            {
                StorageFile SavedCache = await ApplicationData.Current.LocalCacheFolder.CreateFileAsync(file, CreationCollisionOption.ReplaceExisting);
                using (Stream write = await SavedCache.OpenStreamForWriteAsync())
                {
                    DataContractSerializer kek = new DataContractSerializer(typeof(Dictionary<string, string>));
                    kek.WriteObject(write, data);
                    await write.FlushAsync();
                    write.Dispose();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Probleme avec le cache : " + e.Message);
            }
            return true;
        }

        public async Task<bool> Save(string file, String data)
        {
            try
                { 
                    StorageFile SavedCache = await ApplicationData.Current.LocalCacheFolder.CreateFileAsync(file, CreationCollisionOption.ReplaceExisting);
                    using (Stream write = await SavedCache.OpenStreamForWriteAsync())
                     {
                        DataContractSerializer kek = new DataContractSerializer(typeof(string));
                        kek.WriteObject(write, data);
                        await write.FlushAsync();
                        write.Dispose();
                     }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Probleme avec le cache : " + e.Message);
            }
            return true;
        }

        public async Task<Dictionary<string, string>> get(string file)
        {
            var Read = await ApplicationData.Current.LocalCacheFolder.OpenStreamForReadAsync(file);
            if (Read == null)
                return new Dictionary<string, string>();
            DataContractSerializer saveddata = new DataContractSerializer(typeof(Dictionary<string, List<string>>));
            var result = (Dictionary<string, string>)saveddata.ReadObject(Read);
            return result;
        }

        public async Task<String> getString(string file)
        {
            var Read = await ApplicationData.Current.LocalCacheFolder.OpenStreamForReadAsync(file);
            if (Read == null)
                return "";
            DataContractSerializer saveddata = new DataContractSerializer(typeof(string));
            var result = (String)saveddata.ReadObject(Read);
            return result;
        }

        public async Task<bool> isCacheExist(string file)
        {
            var Read = await ApplicationData.Current.LocalCacheFolder.OpenStreamForReadAsync(file);
            if (Read == null)
                return false;
            return true;
        }
    }
}
