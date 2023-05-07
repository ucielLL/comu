using Comu.BaseVVM;
using Comu.Helpers;
using Comu.view;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Comu.ViewModel
{
    public class YesOrNoViewM : BaseViewModel
    {
        public YesOrNoViewM()
        {
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Image = "question.png";
            Text = "...";
            Background = "#F8F8FF";
            stateNo = 0;
            stateYes = 0;
             Accelerometer.Start(SensorSpeed.UI);
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        float X = 0;
        float Z = 0;
        X = e.Reading.Acceleration.X * 10;
        Z = e.Reading.Acceleration.Z * 10;
          
        if (X > 5.0 && Z<3 && Z >-3 && stateYes == 0) { stateYes = 1; }
        if (X < -5.0 && stateYes == 1) { ChangeAnswere("Si"); }

        if (Z < -5.0 &&  X < 3 && X > -3 && stateNo == 0) { stateNo = 1; }
        if (Z > 0 && stateNo == 1) { ChangeAnswere("No"); }


    }
    void ChangeAnswere(string message)
    {
        Accelerometer.Stop();
            
            Text = message;     
        switch (message)
        {
            case "Si":
                Image = "si.png";
                Background = "#00FF7F";
               AudioPlayer.GetInstance().Si();
                break;
            case "No":
                Image = "no.png";
                Background = "#DC143C";
                AudioPlayer.GetInstance().No();
                break;
            case "...":
                Image = "question.png";
                Background = "#F8F8FF";
                    break;
            default:
                Image = "question.png";
                Background = "#F8F8FF";
                    if (!Accelerometer.IsMonitoring) Accelerometer.Start(SensorSpeed.UI);
                    break;

        }
    }
        public ICommand GoToCollectionsCommand => new Command(async () =>
        {
            Accelerometer.Stop();
            await NavigationTo(new CollectionsViewModel());

           
        });
     public ICommand ResetCommand => new Command(() =>
      {
           stateNo = 0;
           stateYes = 0;
           ChangeAnswere("...");
           Accelerometer.Start(SensorSpeed.UI);
      });

    int stateYes = 0;
    int stateNo = 0;

    #region properties
    string image;
    public string Image
    {
        get { return image; }
        set { SetProperty(ref image, value); }
    }
        
        string text;
      
        public string Text
    {
        get { return text; }
        set { SetProperty(ref text, value); }

    }

        string background;
        public string Background
    {
        get { return background; }
        set { SetProperty(ref background, value); }

    }

        
        #endregion

    }
}


