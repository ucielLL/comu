using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Comu.Helpers
{
    public sealed class ImageMedia
    {
        private static ImageMedia _ImageMedia;
        public static ImageMedia GetInstance()
        {
            if (_ImageMedia == null)
            {
                _ImageMedia = new ImageMedia();
            }
            return _ImageMedia;
        }


        public async Task<String> SearchImage()
        {
            try
            {
                if (!CrossMedia.Current.IsTakePhotoSupported)
                {
                    return String.Empty;
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });

                var stream = file.GetStream();
                
                if (file == null) { return String.Empty; }

                return file.Path;
            }
            catch (Exception) 
            {
                return String.Empty;
            }
           

        }

       
    }
}
