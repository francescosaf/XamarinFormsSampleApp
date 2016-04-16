using System;

using Xamarin.Forms;


	using System;

	using Xamarin.Forms;

	using System.Collections;
	

	namespace SampleApp
	{
		public class App : Application
		{
			public static App Current;

			public App ()
			{
				Current = this;

				var isLoggedIn = true;
				// we remember if they're logged in, and only display the login page if they're not
				if (isLoggedIn) {
					ShowMainPage ();
				}
				
				MessaggingRoute ();

			}
			public void ShowMainPage ()
			{	
				
				MainPage = new MainPage ();
			}

			public void Logout ()
			{
				Properties ["IsLoggedIn"] = false; // only gets set to 'true' on the LoginPage
				
			}


			public void MessaggingRoute(){
				Route route = new Route ();
			route.Date = "20160416";
			route.Dispatched = true;
			route.Revision = 1;
			route.Tracked = true;
			route.VehicleId = "xxxx";
			Step step;
			OrderStep order;
			StepExecution stepExecution;
			Location location;

			//"orderStep":{"id":"a29623ed-ed97-4185-b77f-a2fe4dba8e99","name":"","location":{"address":"via lomazzo 45, 20154, Milano","latLng":[45484226,9170034],"source":"G_GEO","status":"OK","geoAddress":"Via Paolo Lomazzo, 45, 20154 Milano, Italy"},"timeWindows":[],"customFields":{},"loads":{"0":100},"notes":""},"stepExecution":{"timeInSec":-1,"timeOutSec":-1,"autoTimeInSec":-1,"autoTimeOutSec":-1},"isService":false,"idleSec":0,"arrivalSec":32782,"startSec":32782,"endSec":33322,"driveToNextSec":126,"distanceToNextMt":0,"serviceTimeSec":540,"displayLabel":"1.12","dispStartSec":32782,"dispVehicleId":"a4365245-7104-40af-a6ae-d29498f03350"}
		
			for (int i = 0; i < 71; i++) {
				step = new Step ();
				order = new OrderStep ();
				order.Id = "a29623ed-ed97-4185-b77f-a2fe4dba8e" + i;
				order.Name = "Test " + i;
				location = new Location ();
				location.Address = "via lomazzo " + i + ", 20154, Milano";
				location.LatLng = new int[] { i, i };
				order.Location = location;
				stepExecution = new StepExecution ();
				stepExecution.AutoTimeInSec = -1;
				stepExecution.AutoTimeOutSec = -1;
				stepExecution.TimeInSec= -1;
				stepExecution.TimeOutSec = -1;
				step.OrderStep = order;
				step.StepExecution = stepExecution;


				step.DisplayLabel = 1 + "." + i;
				if (i == 0)
					step.Type = "departure";
				else if (i == 35)
					step.Type = "break";
				else if (i==70)
					step.Type = "arrival";
				else
					step.Type = "delivery";
				step.IsService = false;

				step.IdleSec = 0;
				step.ArrivalSec = 32782 + i * 100;
				step.StartSec = 32782 + i * 100;
				step.EndSec = 33322+i * 100;

				route.Steps.Add (step);

			}

				MessagingCenter.Send<App, Route> (this, "Hi",route);
		}


			
		public bool IsExecutableStep (Step step)
		{
			if (step.Type.CompareTo ("delivery") == 0 || step.Type.CompareTo ("pickup") == 0)
				return true;
			else
				return false;

		}

			protected override void OnStart ()
			{
				// Handle when your app starts
			}

			protected override void OnSleep ()
			{
				// Handle when your app sleeps
			}

			protected override void OnResume ()
			{
				// Handle when your app resumes
			}
		}
	}

