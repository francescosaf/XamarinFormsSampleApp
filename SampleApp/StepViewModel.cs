using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleApp
{
		public class StepViewModel : INotifyPropertyChanged
		{
			public ObservableCollection<Step> StepsObservable { get; set; }

			int  stepcount;
			int   violazionicount;
			string testString;
			string stepType;

			public string StepCountText 
			{   
				get
				{
					return string.Format("{0}\nOrdini", StepCount);   
				}
			}

			public int StepCount
			{
				set
				{
					if (stepcount != value)
					{
						stepcount = value;
						OnPropertyChanged("StepCount");
						OnPropertyChanged("StepCountText");
					}
				}
				get
				{
					return stepcount;
				}
			}

			public string ViolazioniCountText 
			{   
				get
				{
					return string.Format("{0}\nViolazioni", ViolazioniCount);   
				}
			}


			public int ViolazioniCount
			{
				set
				{
					if (violazionicount != value)
					{
						violazionicount = value;
						OnPropertyChanged("ViolazioniCount");
						OnPropertyChanged("ViolazioniCountText");
					}
				}
				get
				{
					return violazionicount;
				}
			}

			public string StepType
			{
				set
				{
					if (stepType != value)
					{
						stepType = value;
						OnPropertyChanged("StepType");
					}
				}
				get
				{
					return stepType;
				}
			}	

			public string TestString
			{
				set
				{
					if (testString != value)
					{
						testString = value;
						OnPropertyChanged("TestString");

					}
				}
				get
				{
					return testString;
				}
			}

			public StepViewModel ()
			{
				StepsObservable = new ObservableCollection<Step> ();

				MessagingCenter.Subscribe<App,Route> (this, "Hi", (sender, arg) => {
					//StepsObservable=new ObservableCollection<Step>(arg.Steps);
					StepsObservable.Clear();
					foreach ( Step t in arg.Steps)
					{
					StepType=t.Type;
					TestString=t.Type;
					StepsObservable.Add (t);
					}
					StepCount=StepsObservable.Count;

				});
			}

			#region INotifyPropertyChanged implementation

			public event PropertyChangedEventHandler PropertyChanged;

			#endregion

			protected virtual void OnPropertyChanged(string propertyName)
			{
				if (PropertyChanged != null)
				{
					PropertyChanged(this,
						new PropertyChangedEventArgs(propertyName));
				}
			}

		}



}

