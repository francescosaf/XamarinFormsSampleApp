
using System;
using System.Collections.Generic;

using System.ComponentModel;

namespace SampleApp
{

	public class Location
	{

		//[JsonProperty("address")]
		public string Address { get; set; }

		//[JsonProperty("latLng")]
		public int[] LatLng { get; set; }

		//[JsonProperty("source")]
		public string Source { get; set; }

		//[JsonProperty("status")]
		public string Status { get; set; }

		//[JsonProperty("geoAddress")]
		public string GeoAddress { get; set; }
	}

	public class TimeWindow
	{

		//[JsonProperty("startSec")]
		public int StartSec { get; set; }

		//[JsonProperty("endSec")]
		public int EndSec { get; set; }
	}



	public class OrderStep
	{

		//[JsonProperty("id")]
		public string Id { get; set; }

		//[JsonProperty("name")]
		public string Name { get; set; }

		//[JsonProperty("location")]
		public Location Location { get; set; }

		//[JsonProperty("timeWindows")]
		public TimeWindow[] TimeWindows { get; set; }

		//[JsonProperty("customFields")]
		public Dictionary<string,string> CustomFields { get; set; }

		//[JsonProperty("loads")]
		public Dictionary<string, int> Loads { get; set; }

		//[JsonProperty("notes")]
		public string Notes { get; set; }
	}

	public class StepExecution
	{

		//[JsonProperty("timeInSec")]
		public int TimeInSec { get; set; }

		//[JsonProperty("status")]
		public string Status { get; set; }

		//[JsonProperty("timeOutSec")]
		public int TimeOutSec { get; set; }

		//[JsonProperty("autoTimeInSec", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(-1)]
		public int AutoTimeInSec { get; set; }

		//[JsonProperty("autoTimeOutSec", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(-1)]
		public int AutoTimeOutSec { get; set; }

		//[JsonProperty("pods")]
		public Pods Pods { get; set; }
	}


	public class Note
	{
		//[JsonProperty("text")]
		public string Text { get; set; }
		//[JsonProperty("sec")]
		public int Sec { get; set; }
		//[JsonProperty("latLng")]
		public int[] LatLng { get; set; }

	}
	public class ImagePod
	{
		//[JsonProperty("text", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue("")]
		public string Text { get; set; }
		//[JsonProperty("token")]
		public string Token { get; set; }
		//[JsonProperty("sec")]
		public int Sec { get; set; }
		//[JsonProperty("latLng")]
		public int[] LatLng { get; set; }
	}

	public class Pods
	{
		protected Dictionary<string,ImagePod> _si;
		protected Dictionary<string,ImagePod> _pi;

		//[JsonProperty("pictures")]	
		public Dictionary<string,ImagePod> Pictures {			
			get {
				if (null == _pi)
				{
					_pi = new Dictionary<string,ImagePod>();
				}
				return _pi;
			}
			set {
				_pi = value;
			}  
		}
		//[JsonProperty("signatures")]	
		public Dictionary<string,ImagePod> Signatures {			
			get {
				if (null == _si)
				{
					_si = new Dictionary<string,ImagePod>();
				}
				return _si;
			}
			set {
				_si = value;
			}  
		}

		//[JsonProperty("note")]	
		public Note Note { get; set; }
	}

	public class Step
	{

		//[JsonProperty("type")]
		public string Type { get; set; }

		//[JsonProperty("orderStep")]
		public OrderStep OrderStep { get; set; }

		//[JsonProperty("stepExecution")]
		public StepExecution StepExecution { get; set; }

		//[JsonProperty("isService")]
		public bool IsService { get; set; }

		//[JsonProperty("idleSec")]
		public int IdleSec { get; set; }

		//[JsonProperty("arrivalSec")]
		public int ArrivalSec { get; set; }

		//[JsonProperty("startSec")]
		public int StartSec { get; set; }

		//[JsonProperty("endSec")]
		public int EndSec { get; set; }

		//[JsonProperty("driveToNextSec")]
		public int DriveToNextSec { get; set; }

		//[JsonProperty("distanceToNextMt")]
		public int DistanceToNextMt { get; set; }

		//[JsonProperty("groupId", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(-1)]
		public int GroupId { get; set; } 

		//[JsonProperty("displayLabel")]
		public string DisplayLabel { get; set; } 

		//[JsonProperty("serviceTimeSec", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(0)]
		public int ServiceTimeSec { get; set; }

		//[JsonProperty("dispStartSec", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(-1)]
		public int DispStartSec { get; set; }

		//[JsonProperty("dispVehicleId", DefaultValueHandling = DefaultValueHandling.Populate)]
		public string DispVehicleId { get; set; }

	}

	//[JsonObject(IsReference = true)]
	public class Route
	{

		//[JsonProperty("revision")]
		public int Revision { get; set; }

		//[JsonProperty("dispatched", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(true)]
		public bool Dispatched { get; set; }

		//[JsonProperty("tracked", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(true)]
		public bool Tracked { get; set; }

		//[JsonProperty("vehicleId")]
		public string VehicleId { get; set; }

		//[JsonProperty("date")]
		public string Date { get; set; }

		protected List<Step> _Steps;
		//[JsonProperty("steps", DefaultValueHandling = DefaultValueHandling.Populate)]
		public List<Step> Steps
		{
			get
			{
				if (null == _Steps)
				{
					_Steps = new List<Step>();
				}
				return _Steps;
			}
			set
			{
				_Steps = value;
			}
		}
	}

	public class VoloRoutesReponse
	{

		protected List<Route> _Routes;

		//[JsonProperty("routes")]
		public List<Route> Routes
		{
			get
			{
				if (null == _Routes)
				{
					_Routes = new List<Route>();
				}
				return _Routes;
			}
			set
			{
				_Routes = value;
			}
		}

		//[JsonProperty("eventIssues")]
		public Dictionary<string,string> EventIssues;

	}

}


